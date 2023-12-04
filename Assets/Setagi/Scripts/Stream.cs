using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    Vector3 speed;
    Rigidbody m_Rigidbody;
    Vector3 OLD_Position;
    public float m_Thrust = 20f;
    private void Start()
    {
        OLD_Position = transform.position;
    }

    private void FixedUpdate()
    {
        speed = (transform.position - OLD_Position) / Time.deltaTime;
        OLD_Position = transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.tag == "Boat"&& speed != new Vector3(0,0,0))
        {
            m_Rigidbody = other.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(transform.forward * m_Thrust/10);
        }
    }
}
