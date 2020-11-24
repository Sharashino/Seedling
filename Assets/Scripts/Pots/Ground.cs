using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public ParticleSystem growParticles;
    public GameObject grownPlant;
    public GameObject potGround;
    public bool hasSeedling = false;
    GameObject newSeedling;
    public void PlantASeedling(Seed seedlingToPlant)
    {
        //if ground has no seedling plant a new one
        //but if it has, replace them
        if(!hasSeedling)
        {
            hasSeedling = true;
            newSeedling = Instantiate(seedlingToPlant.itemObject);
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
            CreateGrowParticles();
        }
        else
        {
            Destroy(newSeedling);
            newSeedling = Instantiate(seedlingToPlant.itemObject);
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
            CreateGrowParticles();
        }
    }

    void CreateGrowParticles()
    {
        growParticles.Play();
    }
}
