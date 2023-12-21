
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
        [SerializeField] public float objectHealth;
        [SerializeField] private float maxDamageTake = 0;
        [SerializeField][Range(1f, 100f)] private float damageReduction;
        [SerializeField] private GameObject distructObject;

        [SerializeField] private List<string> materials = new List<string>();

        Distruction dist;
        Strength obj;
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
            TransferDamage(damage);
            if (objectHealth <= 0) dist.Disctruct(gameObject, distructObject);

        }

        //Function take shock wave damage
        public void WaveDamage(float damage, Vector3 transformObj, float explosionMinForce, float explosionMaxForce, float explosionForceRadius)
        {
            /* Debug.Log($"WaveDamage = {damage}"); */
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            TransferDamage(damage);
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

                Destroy(gameObject);
            }
        }

        //Function that transfer damage on other parts 
        private void TransferDamage(float damage)
        {
            //Debug.Log("Transfer Damage");
            if (obj != null && damage > maxDamageTake)
            {
                //Debug.Log("Colide ok");
                obj.DamageToOtherPart(damage - maxDamageTake);
            }
        }

        private void DamageToOtherPart(float damage)
        {
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            TransferDamage(damage);
            if (objectHealth <= 0) dist.Disctruct(gameObject, distructObject);
        }

        #region TriggersCheck
        private void OnTriggerStay(Collider other)
        {
            if (other.GetType() == typeof(BoxCollider) && other.CompareTag("Distruct") && other != this.gameObject)
            {
                //partInCollision = true;
                //Debug.Log($"Collision {partInCollision}");
                obj = other.transform.GetComponent<Strength>();
            }
        }
        /*  private void OnTriggerExit(Collider other)
         {

             if (other.GetType() == typeof(BoxCollider) && other.CompareTag("Distruct"))
             {
                 partInCollision = false;
                 print("Collision Exit");

             }
         } */
        #endregion



    }

}
