using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dist;


public class ClickDamage : MonoBehaviour
{


    Strength str;
    void Start()
    {
        str = gameObject.AddComponent<Strength>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                Strength obj = hit.transform.GetComponent<Strength>();
                if (obj != null)
                {
                    obj.GetDamage(10);
                }

            }
        }
    }
}
