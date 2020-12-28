﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefineSeedling : MonoBehaviour
{
    [SerializeField] private NotificationDisplayer notificationDisplayer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SeedlingManager seedlingManager;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject seedlingSelector;
    [SerializeField] private TMP_Text seedlingName;
    [SerializeField] private TMP_Text seedlingTime;
    [SerializeField] private TMP_Text seedlingCuriosity;
    [SerializeField] private Image seedlingImage;
    [SerializeField] private Seed seedling;

    // Start is called before the first frame update
    void Start()
    {
        seedlingName.text = seedling.itemName;
        seedlingCuriosity.text = seedling.seedlingCuriosity;
        seedlingImage.sprite = seedling.itemIcon;

        switch (seedling.itemName)
        {
            case "Iris Seeds":
                seedlingTime.text = gameManager.GetIrisTimeSpent() + " / " + seedling.minutesToGrow;
                break;
            case "Rose Seeds":
                seedlingTime.text = gameManager.GetRoseTimeSpent() + " / " + seedling.minutesToGrow;
                break;
            case "Tulip Seeds":
                seedlingTime.text = gameManager.GetTulipTimeSpent() + " / " + seedling.minutesToGrow;
                break;
            default:
                break;
        }
    }

    public void UpdatePanel(string seedlingName)
    {
        switch (seedlingName)
        {
            case "Iris Seeds":
                seedlingTime.text = gameManager.GetIrisTimeSpent() + " / " + seedling.minutesToGrow;
                break;
            case "Rose Seeds":
                seedlingTime.text = gameManager.GetRoseTimeSpent() + " / " + seedling.minutesToGrow;
                break;
            case "Tulip Seeds":
                seedlingTime.text = gameManager.GetTulipTimeSpent() + " / " + seedling.minutesToGrow;
                break;
            default:
                break;
        }
    }

    public void ChoseSeedling()
    {
        if (seedlingManager.GetCurrentSeedling() == null)
        {
            timer.SetActive(true);
            seedlingManager.SetCurrentSeedling(seedling);
            seedlingManager.PlantSeedling(seedling);
            notificationDisplayer.PlantedSeedling(seedling);
        }
        else if (seedlingManager.GetCurrentSeedling() != seedling && !seedlingManager.GetIsReadyToHarvest())
        {
            timer.SetActive(true);
            seedlingManager.SetCurrentSeedling(seedling);
            seedlingManager.PlantSeedling(seedling);
            notificationDisplayer.PlantedSeedling(seedling);
        }
        else if (seedlingManager.GetCurrentSeedling() == seedling && !seedlingManager.GetIsReadyToHarvest())
        {
            timer.SetActive(true);
            notificationDisplayer.YouPlantedThisArleady();
        }
        else if(seedlingManager.GetIsReadyToHarvest())
        {
            timer.SetActive(true);
            notificationDisplayer.HarvestReminder();
        }
        else
        {
            notificationDisplayer.YouPlantedThisArleady();
        }
    }

    public Seed ReturnSeed()
    {
        return seedling;
    }
}
