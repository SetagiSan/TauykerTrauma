using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{

    public GameObject player;

    public void SetParent(GameObject newParent)
    {
        player.transform.parent = newParent.transform;
    }
}
