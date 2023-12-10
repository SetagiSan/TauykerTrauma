using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dist
{


    public class ResistanceCalculator : MonoBehaviour
    {
        //Просчет уменьшения взрывного урона
        public static float ExplosionReduction(List<string> materials)
        {
            float explosionReduction = 0;
            for (int i = 0; i < materials.Count; i++)
            {
                switch (materials[i])
                {
                    case "Stone":
                        explosionReduction += 10;
                        break;
                    case "Steel":
                        explosionReduction -= 10;
                        break;

                }
            }
            return explosionReduction;
        }
    }
}