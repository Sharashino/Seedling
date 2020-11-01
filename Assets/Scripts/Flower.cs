using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public bool isMature;
    public string flowerName;
    public Ground flowerGround;
    public GameObject flowerObject;

    public void GrowFlower(GameObject seedlingToGrowFrom, GameObject plantedOnGround)
    {
        GameObject Flower = Instantiate(flowerObject, new Vector3(seedlingToGrowFrom.transform.position.x, seedlingToGrowFrom.transform.position.y + 0.25f, seedlingToGrowFrom.transform.position.z), seedlingToGrowFrom.transform.rotation);
        Flower.name = flowerName;
        isMature = true;

        Flower.transform.parent = plantedOnGround.transform;

        Debug.Log("Your " +flowerName +" has grown up!");
    }
}
