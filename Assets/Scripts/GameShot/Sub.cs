using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float Turn = 2f; // �������� ���������
    [SerializeField] private float GyroSpeed = 100f; // ���� ��������� (��� ���� ��������, ��� ������)
    Rigidbody m_Rigidbody;
    private Rigidbody rb;
    private Rigidbody mainrb;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        mainrb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (transform.eulerAngles.x != 0)    // ��� ��� X (������� ������)
        {
            // print(transform.eulerAngles.x);
            if (transform.eulerAngles.x > 2 && transform.eulerAngles.x < 180)
                m_Rigidbody.AddTorque(transform.right * (-1) * (transform.eulerAngles.x / GyroSpeed));
            else if (transform.eulerAngles.x < 358 && transform.eulerAngles.x > 180)
            {
                m_Rigidbody.AddTorque(transform.right * (1) * ((360 - transform.eulerAngles.x) / GyroSpeed));
            }
        }
        if (transform.eulerAngles.z != 0)    // ��� ��� z (����� ������)
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
            m_Rigidbody.AddForce(transform.forward * -1 * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.AddTorque(transform.up * 1 * Turn);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.AddTorque(transform.up * -1 * Turn);
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

    /* private void ChildForce(Transform trans, int force)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            rb = trans.GetChild(i).GetComponent<Rigidbody>();
            rb.AddForce(trans.forward * force);
        }
    } */
    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Space))
        {
            
            for (int i = 0; i < transform.childCount; i++)
            {
                rb = transform.GetChild(i).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 100f);
            }
            mainrb.AddForce(transform.forward * 100f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                rb = transform.GetChild(i).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * -100f);
            }
            mainrb.AddForce(transform.forward * -100f);
        } */
    }
}
