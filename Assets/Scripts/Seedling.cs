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

    public void IGotPlanted()
    {
        isPlanted = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void IGotWateredDown()
    {
        canGrow = true;
        grownPlant.GetComponent<Flower>().GrowFlower(gameObject);
        Destroy(gameObject);
        //tell flower that it got watered down
        //pass seedling to get 
    }

    public void IGotPickedUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
