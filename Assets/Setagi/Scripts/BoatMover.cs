using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoatMover : MonoBehaviour
{
    public float Speed;
    [SerializeField] private float Turn; // скорость разворота
    [SerializeField] private float GyroSpeed; // сила гироскопа (чем выше значение, тем слабее)
    Rigidbody m_Rigidbody;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (transform.eulerAngles.x != 0)    // для оси X (красный вектор)
        {
           // print(transform.eulerAngles.x);
            if (transform.eulerAngles.x > 2 && transform.eulerAngles.x < 180)
                m_Rigidbody.AddTorque(transform.right * (-1) * (transform.eulerAngles.x / GyroSpeed));
            else if (transform.eulerAngles.x < 358 && transform.eulerAngles.x > 180)
            {
                m_Rigidbody.AddTorque(transform.right * (1) * ((360 - transform.eulerAngles.x) / GyroSpeed));
            }
        }
        if (transform.eulerAngles.z != 0)    // для оси z (синий вектор)
        {
            // print(transform.eulerAngles.z);
            if (transform.eulerAngles.z > 2 && transform.eulerAngles.z < 180)
                m_Rigidbody.AddTorque(transform.forward * (-1) * (transform.eulerAngles.z / GyroSpeed));
            else if (transform.eulerAngles.z < 358 && transform.eulerAngles.z > 180)
            {
                m_Rigidbody.AddTorque(transform.forward * (1) * ((360 - transform.eulerAngles.z) / GyroSpeed));
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
