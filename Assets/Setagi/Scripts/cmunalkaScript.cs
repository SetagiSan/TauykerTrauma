using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmunalkaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    private int[,,] blocks;
    private GameObject[,,] blocksRef;
    private int MassValume = 10;
    // Start is called before the first frame update
    void Start()
    {
        blocks = new int[MassValume,MassValume,MassValume];
        blocksRef = new GameObject[MassValume, MassValume, MassValume];
        FixedJoint Connector = null;
        blocks[0,0,0] = 1;
        blocks[0,0,1] = 1;
        blocks[0,1,0] = 1;
        blocks[1,0,0] = 1;
        blocks[1, 0, 1] = 1;
        blocks[1, 1, 1] = 1;
        blocks[1, 1, 0] = 1;
        blocks[1, 1, 1] = 1;
        for (int INDEX0 = 0; INDEX0 < MassValume; INDEX0++) 
        { 
            for (int INDEX1 = 0;INDEX1 < MassValume; INDEX1++)
            {
                for (int INDEX2 = 0;INDEX2 < MassValume; INDEX2++)
                {
                    if (blocks[INDEX0,INDEX1,INDEX2] == 1)
                    {
                        blocksRef[INDEX0,INDEX1,INDEX2] = Instantiate(cube, transform.position + new Vector3(INDEX0, INDEX1, INDEX2), Quaternion.identity);
                        blocksRef[INDEX0, INDEX1, INDEX2].AddComponent<Rigidbody>();
                        if (INDEX0 - 1 >= 0 && blocksRef[INDEX0-1,INDEX1,INDEX2] ) {
                            Connector = blocksRef[INDEX0, INDEX1, INDEX2].AddComponent<FixedJoint>();
                            Connector.connectedBody = blocksRef[INDEX0 - 1, INDEX1, INDEX2].GetComponent<Rigidbody>();
                        }
                        if (INDEX1 - 1 >= 0 && blocksRef[INDEX0, INDEX1-1, INDEX2])
                        {
                            Connector = blocksRef[INDEX0, INDEX1, INDEX2].AddComponent<FixedJoint>();
                            Connector.connectedBody = blocksRef[INDEX0, INDEX1-1, INDEX2].GetComponent<Rigidbody>();
                        }
                        if (INDEX2 - 1 >= 0 && blocksRef[INDEX0, INDEX1, INDEX2-1])
                        {
                            Connector = blocksRef[INDEX0, INDEX1, INDEX2].AddComponent<FixedJoint>();
                            Connector.connectedBody = blocksRef[INDEX0, INDEX1, INDEX2-1].GetComponent<Rigidbody>();
                        }
                    }
                }
            }
        }
            Connector.connectedBody = blocksRef[0, 1, 0].GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
