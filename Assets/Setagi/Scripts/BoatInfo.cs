using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInfo : MonoBehaviour
{
    public float pressure;
    public float WaterPressure=1000;
    public float g = 10;
    public float Volume = 10;
    public float Temperature = 10;

    private void Start()
    {
        pressure = WaterPressure * g * Volume* Temperature / 10;

    }
}
