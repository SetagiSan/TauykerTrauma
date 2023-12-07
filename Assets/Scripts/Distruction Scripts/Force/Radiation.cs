using Dist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
    [SerializeField] private float epicenterDamage = 50f;
    private float radRadius;
   
    private bool onTrigger = false;
    private Strength obj;
    float distance;
    Collider otherCollider;
    // Start is called before the first frame update
    void Start()
    {
        radRadius = gameObject.GetComponent<SphereCollider>().radius;
    }
    private void FixedUpdate()
    {
        if(onTrigger && otherCollider != null)
        {
            obj = otherCollider.GetComponent<Strength>();
            distance = Vector3.Distance(otherCollider.transform.position, gameObject.transform.position);
            RadDamage();
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Distruct"))
            {
            otherCollider = other;
            onTrigger = true;
            Debug.Log(other);
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

    private void RadDamage()
    {
        Debug.Log("Radiation");
        float reduction = radRadius / distance / 100f;
        if (obj != null)
        {
            obj.RadiationDamage(epicenterDamage * reduction);
        }
    }
    
}
