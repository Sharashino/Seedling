using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public string flowerName;
    public GameObject flowerObject;
    public bool ableToGrow;

    private void Update()
    {
        
    }

    public void GrowFlower(GameObject seedling)
    {
        GameObject Flower = Instantiate(flowerObject, seedling.transform.position, seedling.transform.rotation);
        Flower.name = flowerName;

        Debug.Log("Your " +flowerName +" has grown up!");
    }

}
