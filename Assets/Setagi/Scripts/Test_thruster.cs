using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Thruster : MonoBehaviour
{
    [SerializeField] private float Turn;
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.AddTorque(transform.up * 1 * Turn);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.AddTorque(transform.up * -1 * Turn);
        }
    }
}
