using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoatMover : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Turn; // скорость разворота
    Rigidbody m_Rigidbody;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (transform.eulerAngles.x != 0)    // оставил для тестов
        {
            print(transform.eulerAngles.x);
            if (transform.eulerAngles.x > 2 && transform.eulerAngles.x < 180)
                m_Rigidbody.AddTorque(transform.right * (-1) * (transform.eulerAngles.x / 10));
            else if (transform.eulerAngles.x < 358 && transform.eulerAngles.x > 180)
            {
                m_Rigidbody.AddTorque(transform.right * (1) * ((360 - transform.eulerAngles.x) / 10));
            }
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
            m_Rigidbody.AddTorque(transform.up* 1 * Turn);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.AddTorque(transform.up* -1 * Turn);
        }
        if (Input.GetKey(KeyCode.E))
        {
            m_Rigidbody.AddTorque(transform.right * 1 * Turn);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_Rigidbody.AddTorque(transform.right * -1 * Turn);
        }
        #endregion

    }
}
