
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dist;

namespace Dist
{
   
    public class Strength : MonoBehaviour
    {
        #region Var
        [SerializeField] private float objectHealth;
        [SerializeField][Range(1f, 100f)] private float damageReduction;
        [SerializeField] private GameObject distructObject;
        
        [SerializeField] private List<string> materials = new List<string>();

        Distruction dist;

        private GameObject fractObj;
        #endregion



        private void Start()
        {
            dist = gameObject.AddComponent<Distruction>();
            if(materials.Count > 0 )
            {
                damageReduction = ResistanceCalculator.ExplosionReduction(materials);
            }
            Debug.Log($"{gameObject.name} Damage Reduction: {damageReduction}");
            
        }
        
        //Функция получения урона
        public void GetDamage(float damage)
        {
            Debug.Log("Damage");
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            if (objectHealth <= 0) dist.Disctruct(gameObject, distructObject);
        }

        //Функция получения урона от ударной волны
        public void WaveDamage(float damage, Vector3 transformObj, float explosionMinForce, float explosionMaxForce, float explosionForceRadius)
        {
            Debug.Log($"WaveDamage = {damage}");
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
                        Debug.Log(rb);
                        rb.AddExplosionForce(100, transformObj, 100);
                    }
                }

            }
        }

        //Функция нанесения урона радиацией
        public void RadiationDamage(float damage)
        {
            Debug.Log($"Radiation damage = {damage}");
            Debug.Log($"Health : {objectHealth}");
            objectHealth = objectHealth - (damage - (damage * (damageReduction / 100)));
            if (objectHealth <= 0)
            {
                fractObj = Instantiate(distructObject, gameObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);

            }
        }

    }

}
