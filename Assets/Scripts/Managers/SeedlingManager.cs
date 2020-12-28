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

    public void UpdateSeedlingPanels()
    {
        foreach (Seed seedling in seeds)
        {
            seedlingSelector.GetComponentInChildren<DefineSeedling>().UpdatePanel(seedling.itemName);
        }
    }

    public void PlantSeedling(Seed seedlingToPlant)
    {
        seedlingGround.PlantASeedling(seedlingToPlant);
        audioManager.PlaySound("PlaceSeedling");
    }

    public void DoneGrowing()
    {
        UpdateSeedlingPanels();
        audioManager.PlaySound("DoneGrowing");
    }

    public void GrowFlower(Seed seedlingToGrow)
    {
        currentSeedling.itemObject.GetComponent<Seedling>().GrowFlower(currentSeedling.itemObject, seedlingGround.gameObject);
        notificationDisplayer.GrowSeedling(seedlingToGrow);
        audioManager.PlaySound("GrowthComplete");
        SetIsReadyToHarvest(true);
    }

    public void HarvestFlower(Flower flowerToHarvest)
    {
        timeManager.SetTimerButtons(true);
        timeManager.SetTimerText("00:00:00");

        flowerToHarvest.HarvestFlower(flowerToHarvest.gameObject);
        notificationDisplayer.HarvestFlower(flowerToHarvest.GetComponent<Flower>());

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

        SetCurrentSeedling(null);
        SetIsReadyToHarvest(false);
        UpdateSeedlingPanels();
        gameManager.UpdateCoins();
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
