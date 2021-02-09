using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private FlowerTypes flowerType;
    [SerializeField] private string flowerName;
    [SerializeField] private GameObject flowerObject;
    [SerializeField] private Seed flowerSeedling;

    public void HarvestFlower(GameObject flowerToHarvest)
    {
        flowerToHarvest.GetComponentInParent<Ground>().RemoveSeedling();
        Destroy(flowerToHarvest);
    }

    public string FlowerName
    { 
        get
        {
            return flowerName;
        }
    }
    
    public FlowerTypes FlowerType
    {
        get
        {
            return flowerType;
        }
    }

    public Seed FlowerSeedling
    {
        get
        {
            return flowerSeedling;
        }
    }
}
