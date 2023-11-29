using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoatMover : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    Rigidbody m_Rigidbody;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (transform.rotation.x != 0)
        {
            print(transform.eulerAngles.x);
            if (transform.rotation.x < 0)
            transform.Rotate(transform.rotation.x*10, 0,0);
            else transform.Rotate(-transform.rotation.x*10, 0, 0);
        }
        #region Controller
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.AddForce(transform.forward * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.AddForce(transform.forward* -1 * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            m_Rigidbody.AddForce(Vector3.up * Speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_Rigidbody.AddForce(Vector3.down * Speed);
        }
        #endregion

    }
}
