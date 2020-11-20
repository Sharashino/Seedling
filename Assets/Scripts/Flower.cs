using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public string flowerName;
    public GameObject flowerGround;
    public GameObject flowerObject;
    
    private GameObject flower;
        
    //When Flower got Watered Down enough times
    public void GrowFlower(GameObject seedlingToGrowFrom, GameObject plantedOnGround)
    {
        //Getting Ground and spawning Grown Flower on it
        flowerGround = plantedOnGround;
        flower = Instantiate(flowerObject, new Vector3(seedlingToGrowFrom.transform.position.x, seedlingToGrowFrom.transform.position.y + 0.25f, seedlingToGrowFrom.transform.position.z), seedlingToGrowFrom.transform.rotation);
        flower.name = flowerName;

        //Setting up Ground as Flower parent
        flower.transform.parent = plantedOnGround.transform;

        Debug.Log("Your " +flowerName +" has grown up!");
    }

    //When player harvests the Flower destroy it and make Ground plantable again
    public void HarvestFlower(GameObject flowerToHarvest)
    {
        Debug.Log("You harvested " + flowerToHarvest.name);
        
        //Destroying Flower
        Destroy(flowerToHarvest);

        //Making Ground plantable again
    }
}
