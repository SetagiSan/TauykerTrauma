using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private enum vector {
    forward = 0, backward = 1, up = 2, down = 3, right = 4, left = 5
    };
    Vector3 speed;
    Rigidbody m_Rigidbody;
    Vector3 OLD_Position;
    public float m_Thrust = 20f;
    [SerializeField] 
    vector vectorFact;
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
        if (vectorFact == vector.forward)
        {
            if (other.gameObject.tag == "Boat" && speed.z > 0.1)
            {
                m_Rigidbody = other.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(transform.forward * speed.z / 2);
            }
        }
        if (vectorFact == vector.backward)
        {
            if (other.gameObject.tag == "Boat" && -speed.z >0.1)
            {
                m_Rigidbody = other.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(transform.forward * speed.z / 2);
            }

        }
        if (vectorFact == vector.up)
        {
            if (other.gameObject.tag == "Boat" && speed.y >0.1)
            {
                m_Rigidbody = other.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(transform.up * speed.y / 2);
            }

        }
        if (vectorFact == vector.down)
        {
            if (other.gameObject.tag == "Boat" && -speed.y > 0.1)
            {
                print(transform.up * speed.y / 2);
                m_Rigidbody = other.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(transform.up * speed.y / 2);
            }

        }
        if (vectorFact == vector.right)
        {
            if (other.gameObject.tag == "Boat" && speed.x > 0.1)
            {
                m_Rigidbody = other.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(transform.right * speed.x / 2);
            }

        }
        if (vectorFact == vector.left)
        {
            if (other.gameObject.tag == "Boat" && -speed.x > 0.1)
            {
                m_Rigidbody = other.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(transform.right * speed.x / 2);
            }

        }

    }
}
