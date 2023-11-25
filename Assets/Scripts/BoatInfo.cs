using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInfo : MonoBehaviour
{
    public float pressure;
    public float WaterPressure=1000;
    public float g = 10;
    public float V = 10;

    private void FixedUpdate()
    {
        pressure = WaterPressure * g * V;
    }
}
