using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_engine : MonoBehaviour
{
    [SerializeField]    private float Speed;
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.AddForce(transform.forward * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.AddForce(transform.forward * -1 * Speed);
        }
    }
}
