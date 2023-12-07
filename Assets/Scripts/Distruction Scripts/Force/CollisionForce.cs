using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dist;

public class CollisionForce : MonoBehaviour
{
    [SerializeField] private float maxCollisionVelocity = 0f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Distruct"))
        {
            Debug.Log(other.relativeVelocity.magnitude);
            if (other.relativeVelocity.magnitude > maxCollisionVelocity)
            {

                Strength obj = other.transform.GetComponent<Strength>();
                if (obj != null)
                {
                    obj.GetDamage(other.relativeVelocity.magnitude);
                }

            }
        }

    }
}
