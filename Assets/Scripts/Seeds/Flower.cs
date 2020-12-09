using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public string flowerName;
    public GameObject flowerObject;
    private GameObject flower;

        
    //When Flower got Watered Down enough times
    public void GrowFlower(GameObject seedlingToGrowFrom)
    {
        //Getting Ground and spawning Grown Flower on it
        flower = Instantiate(flowerObject, new Vector3(seedlingToGrowFrom.transform.position.x, seedlingToGrowFrom.transform.position.y + 0.1f, seedlingToGrowFrom.transform.position.z), seedlingToGrowFrom.transform.rotation) as GameObject;
        seedlingToGrowFrom.GetComponentInParent<Ground>().newSeedling = flower;
        flower.name = flowerName;

        //Setting up Ground as Flower parent
        flower.transform.parent = seedlingToGrowFrom.transform.parent;
        Debug.Log("Your " +flowerName +" has grown up!");
        Destroy(seedlingToGrowFrom.gameObject);
    }

    //When player harvests the Flower destroy it and make Ground plantable again
    public void HarvestFlower(GameObject flowerToHarvest)
    {
        //Making Ground plantable again
        Debug.Log("You harvested " + flowerToHarvest.name);
        flowerToHarvest.GetComponentInParent<Ground>().hasSeedling = false;
        Destroy(flowerToHarvest.gameObject);
    }
}
