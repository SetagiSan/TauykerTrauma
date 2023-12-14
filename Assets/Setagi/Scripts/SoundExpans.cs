using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SoundExpans : MonoBehaviour
{
    [SerializeField] private float SoundDistance;
    [SerializeField] private float SoundExpansSpeed;
    [SerializeField] private float SoundExpansLifeTime;
    public RaycastHit hit;
    void Start()
    {
        transform.localScale = new Vector3(1,1,1);
        Destroy(gameObject, SoundExpansLifeTime);
    }

    void FixedUpdate()
    {
        if (transform.localScale.magnitude <= SoundDistance)
        {
            transform.localScale *= SoundExpansSpeed;
        }
        else Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boat") {
            Ray ray = new Ray(transform.position, other.transform.position - transform.position);
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.green);
            Physics.Raycast(ray, out hit);
            if (hit.collider.tag == "Boat") {
                print(hit.collider.bounds.extents);
            }
        }
    }
}
