using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class termoExport : MonoBehaviour
{
    private PartInfo SelfInfo;
    private void Start()
    {
        SelfInfo = gameObject.GetComponent<PartInfo>();
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PartInfo>() != null)
        {
            PartInfo ColInfo = other.GetComponent<PartInfo>();
            if (SelfInfo.Temperature != ColInfo.Temperature)
            {
                ColInfo.Temperature += (SelfInfo.Temperature - ColInfo.Temperature) / 100;
            }
        }
    }
}