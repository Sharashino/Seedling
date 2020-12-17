using UnityEngine;
public class Flower : MonoBehaviour
{
    [SerializeField] private string flowerName;
    [SerializeField] private GameObject flowerObject;
    private GameObject flower;
        
    //When Flower got Watered Down enough times
    public void GrowFlower(GameObject seedlingToGrowFrom, GameObject plantedOnGround)
    {
        //Getting Ground and spawning Grown Flower on it
        flower = Instantiate(flowerObject, new Vector3(seedlingToGrowFrom.transform.position.x, seedlingToGrowFrom.transform.position.y + 0.20f, seedlingToGrowFrom.transform.position.z), seedlingToGrowFrom.transform.rotation);
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

    public string GetFlowerName()
    {
        return flowerName;
    }
}
