using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dist;
public class Explosion : MonoBehaviour
{

    public float explosionMinForce = 5;
    public float explosionMaxForce = 100;
    public float explosionForceRadius = 10;
    public float fragScaleFactor = 1;
    public int damage = 0;
    Strength str;
    // Start is called before the first frame update
    void Start()
    {
        str = gameObject.AddComponent<Strength>();
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Distruct"))
        {
            Debug.Log("Explode");
            Strength obj = other.GetComponent<Strength>();
            obj.WaveDamage(damage, gameObject.transform.position, explosionMinForce, explosionMaxForce, explosionForceRadius);
        }
    }

}
