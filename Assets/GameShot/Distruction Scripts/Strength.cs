
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dist;
using System;

namespace Dist
{

    public class Strength : MonoBehaviour
    {
        #region Var
        [SerializeField] private float objectHealth;
        [SerializeField][Range(1f, 100f)] private float damageReduction;
        [SerializeField] private GameObject distructObject;

        [SerializeField] private List<string> materials = new List<string>();

        private bool partInCollision = true;

        Distruction dist;
        private GameObject fractObj;
        #endregion



        private void Start()
        {
            dist = gameObject.AddComponent<Distruction>();
            if (materials.Count > 0)
            {
                damageReduction = ResistanceCalculator.ExplosionReduction(materials);
            }


        }

        //Damage function
        public void GetDamage(float damage)
        {
            Debug.Log("Damage");
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            if (objectHealth <= 0) dist.Disctruct(gameObject, distructObject);
        }

        //Function take shock wave damage
        public void WaveDamage(float damage, Vector3 transformObj, float explosionMinForce, float explosionMaxForce, float explosionForceRadius)
        {
            /* Debug.Log($"WaveDamage = {damage}"); */
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            if (objectHealth <= 0)
            {
                fractObj = Instantiate(distructObject, gameObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                foreach (Transform t in fractObj.transform)
                {
                    var rb = t.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(100, transformObj, 100);
                    }
                }

            }
        }

        //Function take radiation damage
        public void RadiationDamage(float damage)
        {
            /*  Debug.Log($"Radiation damage = {damage}");
             Debug.Log($"Health : {objectHealth}"); */
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            if (objectHealth <= 0)
            {
                fractObj = Instantiate(distructObject, gameObject.transform.position, Quaternion.identity) as GameObject;
                TransferDamage();
                Destroy(gameObject);
            }
        }


        //Function that transfer damage on othe parts 
        private void TransferDamage()
        {
            Debug.Log(partInCollision);
            if (partInCollision)
            {
                Debug.Log("Colide ok");
            }
        }


        #region TriggersCheck
        private void OnTriggerStay(Collider other)
        {
            if (other.GetType() == typeof(BoxCollider) && other.CompareTag("Distruct") && partInCollision == false)
            {
                partInCollision = true;
                //Debug.Log($"Collision {partInCollision}");
            }
        }
        private void OnTriggerExit(Collider other)
        {

            if (other.GetType() == typeof(BoxCollider) && other.CompareTag("Distruct"))
            {
                Debug.Log($"Not Collision{partInCollision}");
                partInCollision = false;

            }
        }
        #endregion



    }

}
