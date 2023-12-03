using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.tag == "Boat")
        {
            m_Rigidbody = other.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }
    }
}
