using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using Dist;
using Unity.VisualScripting;



public class NewRadiation : MonoBehaviour
{
    Vector3 randVector;
    Vector3 direction;
    Vector3 objectPosition;
    [SerializeField, Range(1, 10000)] private int RayCastsCount = 1;
    [SerializeField, Range(0.1f, 2)] private float RayCastSpread = 1;
    [SerializeField] private float damage = 1f;
    private Strength obj;

    float colRadius;

    private void Start()
    {
        direction = transform.TransformDirection(Vector3.forward) * 1;
        randVector = new Vector3(Random.Range(1, 10), Random.Range(1, 10), 0);
        colRadius = gameObject.GetComponent<SphereCollider>().radius;
    }
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
    private void FixedUpdate()
    {
        // randVector = new Vector3(Random.Range(1, 10), Random.Range(1, 10), 0);
    }

    private void StartRaycast()
    {
        var results = new NativeArray<RaycastHit>(RayCastsCount, Allocator.TempJob);
        var commands = new NativeArray<RaycastCommand>(RayCastsCount, Allocator.TempJob);

        Vector3 origin = transform.position;
        direction = objectPosition - transform.position;
        direction = Vector3.Normalize(direction);

        for (int i = 0; i < RayCastsCount; i++)
        {

            float ranSpreadX = Random.Range(-RayCastSpread, RayCastSpread);
            float ranSpreadY = Random.Range(-RayCastSpread, RayCastSpread);
            float ranSpreadZ = Random.Range(-RayCastSpread, RayCastSpread);
            randVector = new Vector3(ranSpreadX, ranSpreadY, ranSpreadZ);
            commands[i] = new RaycastCommand(origin, (direction + randVector).normalized, QueryParameters.Default, colRadius);
            print("Raycast");
        }

        JobHandle handle = RaycastCommand.ScheduleBatch(commands, results, 1, 1, default(JobHandle));

        handle.Complete();
        print("Ok");

        foreach (var hit in results)
        {
            if (hit.collider != null && hit.collider.transform.CompareTag("Distruct"))
            {
                obj = hit.collider.GetComponent<Strength>();
                if (obj != null) if (obj.objectHealth > 0) obj.RadiationDamage(damage);
            }
        }

        results.Dispose();
        commands.Dispose();
    }

    private void OnTriggerStay(Collider other)
    {
        objectPosition = other.transform.position;
        if (other.CompareTag("Distruct")) StartRaycast();

    }

    private void OnTriggerExit(Collider other)
    {
        //direction = Vector3.Normalize(direction);
        objectPosition = transform.position;
    }
}

