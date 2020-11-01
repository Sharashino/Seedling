﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public GameObject ground;
    public GameObject grownPlant;
    public string seedlingName;
    public bool isPlanted;
    public bool canGrow;
    public int timesWatered;

    public int plantFirstStage;
    public int plantSecondStage;
    public int plantThirdStage;

    //When seedling got planted
    public void IGotPlanted(GameObject plantedOnGround)
    {
        gameObject.transform.parent = plantedOnGround.transform;
        isPlanted = true;
        ground = plantedOnGround;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    //When seedling got watered down
    public void IGotWateredDown()
    {
        timesWatered++;

        if(timesWatered == plantFirstStage)
        {
            Debug.Log("This seedling requires more time: " + timesWatered + " / " + plantSecondStage);
        }
        else if(timesWatered == plantSecondStage)
        {
            Debug.Log("This seedling requires more time: " + timesWatered + " / " + plantThirdStage);
        }
        else if (timesWatered == plantThirdStage)
        {
            canGrow = true;
            grownPlant.GetComponent<Flower>().GrowFlower(gameObject, ground);
            Destroy(gameObject);
        }
        else if (timesWatered > plantThirdStage)
        {
            Debug.Log("This flower can't be watered now");
        }
    }

    //When picking up seedling turn off its Renderer
    public void IGotPickedUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
