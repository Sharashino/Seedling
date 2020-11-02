using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pot : MonoBehaviour
{
    public GameObject potGround;
    public bool isOccupied = false;
    public bool hasGround = false;

    public void PlaceGround(GameObject groundToPlace)
    {
        //Getting Ground and Pot Transforms
        potGround = groundToPlace;
        Transform groundTransform = groundToPlace.GetComponent<Transform>();
        Transform potTransform = GetComponent<Transform>();
        
        //Moving ground to the centre of the pot
        Vector3 position = groundTransform.position;
        position.x = potTransform.position.x;
        position.y = potTransform.position.y + 0.05f;
        position.z = potTransform.position.z;
        groundTransform.position = position;

        //Setting Ground Pot as parent
        groundToPlace.transform.parent = gameObject.transform;

        //Filling Pot with Ground
        hasGround = true;
    }

    public void PlantASeedling(GameObject seedlingToPlant)
    {
        if(hasGround == true)
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
            isOccupied = true;
        }
    }
}
