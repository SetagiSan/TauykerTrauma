using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Dist
{
    public class Distruction : MonoBehaviour
    {
        [SerializeField] private GameObject distructedObject;

        /* void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log(hit.transform.gameObject.name);

                }
            }
        } */
        public void Disctruct(GameObject fullObject, GameObject distObject)
        {
            Debug.Log("Distruct");
            Destroy(fullObject);
            Instantiate(distObject, fullObject.transform.position, fullObject.transform.rotation);

        }



    }

}
