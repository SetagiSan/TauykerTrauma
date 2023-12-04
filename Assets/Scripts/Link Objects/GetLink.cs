using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetLink : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    // Start is called before the first frame update
    void Start()
    {
        CustomLink CL = new CustomLink();
        CL.AddLink(go1);
        CL.AddLink(go2);
    }


}



