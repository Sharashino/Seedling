using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject grownPlant;
    public GameObject potGround;

    public void PlantASeedling(Seed seedlingToPlant)
    {
        GameObject newSeedling = Instantiate(seedlingToPlant.itemObject);
        grownPlant = seedlingToPlant.itemObject;
        newSeedling.name = seedlingToPlant.name;

        //Getting Seedling and Pot Transforms
        Transform seedlingTransform = newSeedling.GetComponent<Transform>();
        Transform potTransform = potGround.GetComponent<Transform>();

        //Moving seedling to the centre of the pot
        Vector3 position = seedlingTransform.position;
        position.x = potTransform.position.x;
        position.y = potTransform.position.y + 0.05f;
        position.z = potTransform.position.z;
        seedlingTransform.position = position;

        seedlingTransform.parent = potGround.transform;
    }
}
