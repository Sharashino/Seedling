using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public GameObject grownFlower;
    public string seedlingName;
    public bool isPlanted;

    public void IGotPlanted(GameObject plantedSeedling)
    {
        isPlanted = true;
        Debug.Log("Yay!");
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void IGotWateredDown()
    {

    }

    public void IGotPickedUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
