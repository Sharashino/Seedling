using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground2 : MonoBehaviour
{
    private GameObject Pot;

    public bool isInPot = true;
    //When picking up ground
    public void IGotPickedUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    //When placking ground in pot
    public void IGotPlacedInPot()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        isInPot = true;
    }
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

            //Making Pot occupied
            //isOccupied = true;
        }
    }
}
