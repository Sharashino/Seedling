using System;
using UnityEngine;

public class SeedlingManager : MonoBehaviour
{
    [SerializeField] private Seed currentSeedling;
    [SerializeField] private GameObject grownSeedling;
    [SerializeField] private Ground seedlingGround;

    public void GrowFlower()
    {
        currentSeedling.itemObject.GetComponent<Flower>().GrowFlower(currentSeedling.itemObject, seedlingGround.gameObject);
    }

    public void HarvestFlower(GameObject flowerToHarvest)
    {
        flowerToHarvest.GetComponent<Flower>().HarvestFlower(flowerToHarvest);
    }

    public Seed GetCurrentSeedling()
    {
        return currentSeedling;
    }

    public Seed AssingSeedling(Seed seedlingToAssing)
    {
        return currentSeedling = seedlingToAssing;
    }
}
