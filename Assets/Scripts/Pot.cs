using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pot : MonoBehaviour
{
    public GameObject potGround;
    public bool isOccupied = false;
    public bool hasGround;

    private void Start()
    {
        if(GetComponentInChildren<Ground>() != null)
        {
            hasGround = true;
        }
        else
        {
            hasGround = false;
        }
    }


    public void PlantASeedling(GameObject seedlingToPlant)
    {
        if(hasGround == true)
        {
            Seedling seedling = seedlingToPlant.GetComponent<Seedling>();
            Transform seedlingTransform = seedlingToPlant.GetComponent<Transform>();
            Transform potTransform = GetComponent<Transform>();

            //Moving seedle to the centre of the pot
            Vector3 position = seedlingTransform.position;
            position.x = potTransform.position.x;
            position.y = potTransform.position.y + 0.15f;
            position.z = potTransform.position.z;
            seedlingTransform.position = position;

            isOccupied = true;
        }
    }
}
