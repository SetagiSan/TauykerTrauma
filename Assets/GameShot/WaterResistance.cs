using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using Dist;
using Unity.VisualScripting;
using System.Collections;
public class WaterResistance : MonoBehaviour
{
    Vector3 randVector;
    Vector3 direction;
    Vector3 objectPosition;
    [SerializeField, Range(1, 10000)] private int RayCastsCount = 1;
    [SerializeField, Range(0.1f, 2)] private float RayCastSpread = 1;
    [SerializeField, Range(1, 1000)] private int forceReduction = 1;
    [SerializeField, Range(0, 10)] private int secondToWaitRaycasts = 1;
    private Rigidbody rb;
    private bool canNextForce = true;
    float colRadius;

    private void Start()
    {
        direction = transform.TransformDirection(Vector3.forward) * 1;
        randVector = new Vector3(Random.Range(1, 10), Random.Range(1, 10), 0);
        colRadius = gameObject.GetComponent<SphereCollider>().radius;
    }
    //Test debug raycasts
    void Update()
    {
        Vector3 origin = transform.position;
        direction = objectPosition - transform.position;

        float ranSpreadX = Random.Range(-RayCastSpread, RayCastSpread);
        float ranSpreadY = Random.Range(-RayCastSpread, RayCastSpread);
        float ranSpreadZ = Random.Range(-RayCastSpread, RayCastSpread);
        randVector = new Vector3(ranSpreadX, ranSpreadY, ranSpreadZ);
        Debug.DrawRay(origin, direction + randVector, Color.green);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRaycast();
            print("Clicked");
        }
    }
    //Raycasts
    private void StartRaycast()
    {
        canNextForce = false;
        var results = new NativeArray<RaycastHit>(RayCastsCount, Allocator.TempJob);
        var commands = new NativeArray<RaycastCommand>(RayCastsCount, Allocator.TempJob);

        Vector3 origin = transform.position;
        direction = objectPosition - transform.position;
        direction = Vector3.Normalize(direction);

        for (int i = 0; i < RayCastsCount; i++)
        {
            //Vector randomizer
            float ranSpreadX = Random.Range(-RayCastSpread, RayCastSpread);
            float ranSpreadY = Random.Range(-RayCastSpread, RayCastSpread);
            float ranSpreadZ = Random.Range(-RayCastSpread, RayCastSpread);
            randVector = new Vector3(ranSpreadX, ranSpreadY, ranSpreadZ);
            commands[i] = new RaycastCommand(origin, (direction + randVector).normalized, QueryParameters.Default, colRadius);
            print("Raycast");
        }

        JobHandle handle = RaycastCommand.ScheduleBatch(commands, results, 1, 1, default(JobHandle));

        handle.Complete();


        foreach (var hit in results)
        {
            if (hit.collider != null && hit.collider.transform.CompareTag("Distruct"))
            {
                rb = hit.collider.GetComponent<Rigidbody>();
                rb.AddForce(direction / forceReduction, ForceMode.Impulse);
                print("Forse");
            }
        }
        results.Dispose();
        commands.Dispose();
        StartCoroutine(WaitForFunction());
    }

    private void OnTriggerStay(Collider other)
    {
        objectPosition = other.transform.position;
        if (other.CompareTag("Distruct") && canNextForce) StartRaycast();

    }

    //Delay coroutine
    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(secondToWaitRaycasts);
        Debug.Log("Hello!");
        canNextForce = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //direction = Vector3.Normalize(direction);
        objectPosition = transform.position;
    }
}
