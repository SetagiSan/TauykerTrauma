using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BoatInfo : MonoBehaviour
{
    Vector3 speed;
    public float pressure;
    public float WaterPressure=1000;
    public float g = 10;
    public float Volume = 10;
    Vector3 OLD_Position;

    private void Start()
    {
        OLD_Position = transform.position;
    }

    private void FixedUpdate()
    {
        speed = (transform.position - OLD_Position) / Time.deltaTime;
        OLD_Position = transform.position;
        pressure = Mathf.Abs(transform.position.y) * speed.magnitude;//0 ��������� �������� ����
    }
}
