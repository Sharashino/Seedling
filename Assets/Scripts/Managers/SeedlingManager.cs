using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SeedlingManager : MonoBehaviour
{
    [SerializeField] private Seed currentSeedling;
    [SerializeField] private Ground seedlingGround;
    [SerializeField] private NotificationDisplayer notificationDisplayer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject seedlingSelector;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool isReadyToHarvest;

    public List<Seed> seeds = new List<Seed>();

    public void PlantSeedling(Seed seedlingToPlant)
    {
        seedlingGround.PlantASeedling(seedlingToPlant);
        audioManager.PlaySound("PlaceSeedling");
    }

    public void DoneGrowing()
    {
        audioManager.PlaySound("DoneGrowing");
    }

    public void GrowFlower(Seed seedlingToGrow)
    {
        seedlingToGrow.isDoneGrowing = true;
        currentSeedling.itemObject.GetComponent<Seedling>().GrowFlower(currentSeedling.itemObject, seedlingGround.gameObject);
        notificationDisplayer.GrowSeedling(seedlingToGrow);
        audioManager.PlaySound("GrowthComplete");
        SetIsReadyToHarvest(true);
    }

    public void HarvestFlower(Flower flowerToHarvest)
    {
        switch (flowerToHarvest.GetFlowerName())
        {
            case "Iris Flower":
                {
                    gameManager.SetIrisTimeSpent(0);
                    gameManager.SetPlayerCoins(flowerToHarvest.GetFlowerSeedling().harvestCoins);
                }
                break;
            case "Rose Flower":
                {
                    gameManager.SetRoseTimeSpent(0);
                    gameManager.SetPlayerCoins(flowerToHarvest.GetFlowerSeedling().harvestCoins);

                }
                break;
            case "Tulip Flower":
                {
                    gameManager.SetTulipTimeSpent(0);
                    gameManager.SetPlayerCoins(flowerToHarvest.GetFlowerSeedling().harvestCoins);
                }
                break;
            default:
                break;
        }

        notificationDisplayer.HarvestFlower(flowerToHarvest.GetComponent<Flower>());
        
        GetCurrentSeedling().isDoneGrowing = false;
        flowerToHarvest.HarvestFlower(flowerToHarvest.gameObject);

        SetCurrentSeedling(null);
        SetIsReadyToHarvest(false);
        gameManager.UpdateCoins();
        timeManager.SetTimerButtons(true);
        audioManager.PlaySound("HarvestSeedling");
    }

    public bool GetIsReadyToHarvest()
    {
        return isReadyToHarvest;
    }

    public Seed GetCurrentSeedling()
    {
        return currentSeedling;
    }

    public Seed SetCurrentSeedling(Seed seedlingToAssing)
    {
        return currentSeedling = seedlingToAssing;
    }
    public bool SetIsReadyToHarvest(bool isReady)
    {
        return isReadyToHarvest = isReady;
    }

}
