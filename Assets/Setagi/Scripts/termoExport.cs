using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class termoExport : MonoBehaviour
{
    private BoatInfo SelfInfo;
    private void Start()
    {
        SelfInfo = gameObject.GetComponent<BoatInfo>();
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BoatInfo>() != null)
        {
            BoatInfo ColInfo = other.GetComponent<BoatInfo>();
            if (SelfInfo.Temperature != ColInfo.Temperature)
            {
                ColInfo.Temperature += (SelfInfo.Temperature - ColInfo.Temperature) / 100;
            }
        }
    }
}