using UnityEngine;
using UnityEngine.EventSystems;

public class Flower : MonoBehaviour
{
    [SerializeField] private string flowerName;
    [SerializeField] private GameObject flowerObject;
    [SerializeField] private Seed flowerSeedling;

    public void HarvestFlower(GameObject flowerToHarvest)
    {
        flowerToHarvest.GetComponentInParent<Ground>().RemoveSeedling();
        Destroy(flowerToHarvest);
    }

    public string GetFlowerName()
    {
        return flowerName;
    }

    public Seed GetFlowerSeedling()
    {
        return flowerSeedling;
    }
}
