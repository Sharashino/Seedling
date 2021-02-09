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
        isReadyToHarvest = true;
    }

    public void HarvestFlower(Flower flowerToHarvest)
    {
        switch (flowerToHarvest.FlowerType)
        {
            case FlowerTypes.IrisFlower:
                {
                    gameManager.IrisTimeSpent = 0;
                    gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.harvestCoins;
                }
                break;
            case FlowerTypes.RoseFlower:
                {
                    gameManager.RoseTimeSpent = 0;
                    gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.harvestCoins;

                }
                break;
            case FlowerTypes.TulipFlower:
                {
                    gameManager.TulipTimeSpent = 0;
                    gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.harvestCoins;
                }
                break;
            default:
                break;
        }

        notificationDisplayer.HarvestFlower(flowerToHarvest.GetComponent<Flower>());
        
        currentSeedling.isDoneGrowing = false;
        flowerToHarvest.HarvestFlower(flowerToHarvest.gameObject);

        currentSeedling = null;
        IsReadyToHarvest = false;
        gameManager.UpdateCoins();
        timeManager.TimerButtons = false;
        audioManager.PlaySound("HarvestSeedling");
    }

    public bool IsReadyToHarvest
    {
        get
        {
            return isReadyToHarvest;
        }
        set
        {
            isReadyToHarvest = value;
        }
    }

    public Seed CurrentSeedling
    {
        get
        {
            return currentSeedling;
        }
        set
        {
            currentSeedling = value;
        }
    }
}
