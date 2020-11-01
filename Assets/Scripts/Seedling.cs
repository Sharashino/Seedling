using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public GameObject grownPlant;
    public string seedlingName;
    public bool isPlanted;
    public bool canGrow;
    public int timesWatered;
    public int reqWater;
   
    public void IGotPlanted()
    {
        isPlanted = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void IGotWateredDown()
    {
        timesWatered++;

        if(timesWatered == reqWater)
        {
            canGrow = true;
            grownPlant.GetComponent<Flower>().GrowFlower(gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("This flower requires more time: " + timesWatered + " / " + reqWater);
        }
        //tell flower that it got watered down
        //pass seedling to get 
    }

    public void IGotPickedUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
