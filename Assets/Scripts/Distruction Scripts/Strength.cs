
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dist;

namespace Dist
{
    public class Strength : MonoBehaviour
    {
        [SerializeField] private int objectHealth;
        [SerializeField] private int damageReduction;
        [SerializeField] private GameObject distructObject;
        Distruction dist;

        private GameObject fractObj;


        private void Start()
        {
            dist = gameObject.AddComponent<Distruction>();
        }
        public void GetDamage(int damage)
        {
            Debug.Log("Damage");
            objectHealth = objectHealth - (damage * damageReduction / 100);
            if (objectHealth <= 0) dist.Disctruct(gameObject, distructObject);


        }

        public void WaveDamage(int damage, Vector3 transformObj, float explosionMinForce, float explosionMaxForce, float explosionForceRadius)
        {
            Debug.Log("WaveDamage");
            objectHealth = objectHealth - (damage * damageReduction / 100);
            Debug.Log(objectHealth);
            if (objectHealth <= 0)
            {
                fractObj = Instantiate(distructObject, gameObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                foreach (Transform t in fractObj.transform)
                {
                    var rb = t.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Debug.Log(rb);
                        rb.AddExplosionForce(100, transformObj, 100);
                    }
                }
                /* for (int i = 0; i < distructObject.transform.childCount; i++)
                {
                    rb = distructObject.transform.GetChild(i).GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Debug.Log(rb);
                        rb.AddExplosionForce(1000, new Vector3(42, 2, 12), 1000);
                    }
                } */

            }
        }

    }

}
