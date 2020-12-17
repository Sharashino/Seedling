using UnityEngine;
public class Flower : MonoBehaviour
{
    [SerializeField] private string flowerName;
    [SerializeField] private GameObject flowerObject;

    public void HarvestFlower(GameObject flowerToHarvest)
    {
        flowerToHarvest.GetComponentInParent<Ground>().RemoveSeedling();
        Destroy(flowerToHarvest);
    }

    public string GetFlowerName()
    {
        return flowerName;
    }
}
