using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartInfo : MonoBehaviour
{
    public float Temperature = 10;
    private float DefoltTemperature;

    private void Start()
    {
        DefoltTemperature = Temperature;
    }

    private void FixedUpdate()
    {
        print(gameObject.name +" "+ Temperature);
        //если вода не является объектом
        if (Temperature != DefoltTemperature)
            Temperature += (DefoltTemperature - Temperature) / 50;
    }
}
