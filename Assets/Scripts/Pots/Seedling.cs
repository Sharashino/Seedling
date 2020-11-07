using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public GameObject grownPlant;
    public bool isPlanted;
    public int timesWatered;

    public int plantFirstStage;
    public int plantSecondStage;
    public int plantThirdStage;

    public void PlantASeedling(GameObject seedlingToPlant, GameObject plantOnGround)
    {
        GameObject newSeedling = Instantiate(seedlingToPlant);
        newSeedling.name = seedlingToPlant.name;
        //Getting Seedling and Pot Transforms
        Transform seedlingTransform = newSeedling.GetComponent<Transform>();
        Transform potTransform = plantOnGround.GetComponent<Transform>();

        //Moving seedling to the centre of the pot
        Vector3 position = seedlingTransform.position;
        position.x = potTransform.position.x;
        position.y = potTransform.position.y + 0.1f;
        position.z = potTransform.position.z;
        seedlingTransform.position = position;

        seedlingTransform.parent = plantOnGround.transform;

        isPlanted = true;
    }


    //When seedling got watered down
    public void IGotWateredDown()
    {
        timesWatered++;
        //Watered enough times for First Stage
        if(timesWatered == plantFirstStage)
        {
            Debug.Log("This seedling requires more time: " + timesWatered + " / " + plantSecondStage);
        }
        //Watered enough times for Second Stage
        else if (timesWatered == plantSecondStage)
        {
            Debug.Log("This seedling requires more time: " + timesWatered + " / " + plantThirdStage);
        }
        //Watered enough times for Third Stage, grow Flower
        else if (timesWatered == plantThirdStage)
        {
            //grownPlant.GetComponent<Flower>().GrowFlower(gameObject, ground);
            Destroy(gameObject);
        }
        else if (timesWatered > plantThirdStage)
        {
            Debug.Log("This flower can't be watered now");
        }
    }
}
