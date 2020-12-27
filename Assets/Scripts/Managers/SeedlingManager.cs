using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SeedlingManager : MonoBehaviour
{
    [SerializeField] private Seed currentSeedling;
    [SerializeField] private Ground seedlingGround;
    [SerializeField] private NotificationDisplayer notificationDisplayer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private GameObject seedlingSelector;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool isReadyToHarvest;

    public void GrowFlower(Seed seedlingToGrow)
    {
        currentSeedling.itemObject.GetComponent<Seedling>().GrowFlower(currentSeedling.itemObject, seedlingGround.gameObject);
        notificationDisplayer.GrowSeedling(seedlingToGrow);
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
                    gameManager.SetPlayerCoins(15);
                }
                break;
            case "Rose Flower":
                {
                    gameManager.SetRoseTimeSpent(0);
                    gameManager.SetPlayerCoins(30);

                }
                break;
            case "Tulip Flower":
                {
                    gameManager.SetTulipTimeSpent(0);
                    gameManager.SetPlayerCoins(50);
                }
                break;
            default:
                break;
        }

        SetCurrentSeedling(null);
        SetIsReadyToHarvest(false);
        gameManager.UpdateCoins();
        seedlingSelector.GetComponentInChildren<DefineSeedling>().UpdatePanel();
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
