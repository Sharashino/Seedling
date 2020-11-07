using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool isInPot = false;

    public void PlantASeedling(GameObject seedlingToPlant)
    {
        if (isInPot == true)
        {
            //Getting Seedling and Pot Transforms
            Transform seedlingTransform = seedlingToPlant.GetComponent<Transform>();
            Transform potTransform = GetComponent<Transform>();

            //Moving seedling to the centre of the pot
            Vector3 position = seedlingTransform.position;
            position.x = potTransform.position.x;
            position.y = potTransform.position.y + 0.2f;
            position.z = potTransform.position.z;
            seedlingTransform.position = position;
        }
    }
}
