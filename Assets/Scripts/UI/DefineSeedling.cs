using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefineSeedling : MonoBehaviour
{

    [SerializeField] private GameObject notificationDisplayer;
    [SerializeField] private GameObject groundToPlant;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject seedlingSelector;
    [SerializeField] private TMP_Text seedlingName;
    [SerializeField] private TMP_Text seedlingTime;
    [SerializeField] private TMP_Text seedlingCuriosity;
    [SerializeField] private Image seedlingImage;
    [SerializeField] private Seed seedling;
    private GameManager playerManager;

    private void Awake()
    {
        playerManager = gameManager.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        seedlingName.text = seedling.itemName;
        seedlingCuriosity.text = seedling.seedlingCuriosity;
        seedlingImage.sprite = seedling.itemIcon;

        switch (seedlingName.text.ToString())
        {
            case "Iris Seeds":
                seedlingTime.text = playerManager.irisTimeSpent + " / " + seedling.minutesToGrow;
                break;
            case "Rose Seeds":
                seedlingTime.text = playerManager.roseTimeSpent + " / " + seedling.minutesToGrow;
                break;
            case "Tulip Seeds":
                seedlingTime.text = playerManager.tulipTimeSpent + " / " + seedling.minutesToGrow;
                break;
            default:
                break;
        }
    }

    public void UpdatePanel()
    {
        switch (seedlingName.text.ToString())
        {
            case "Iris Seeds":
                seedlingTime.text = playerManager.irisTimeSpent + " / " + seedling.minutesToGrow;
                break;
            case "Rose Seeds":
                seedlingTime.text = playerManager.roseTimeSpent + " / " + seedling.minutesToGrow;
                break;
            case "Tulip Seeds":
                seedlingTime.text = playerManager.tulipTimeSpent + " / " + seedling.minutesToGrow;
                break;
            default:
                break;
        }
    }

    public void ChoseSeedling()
    {
        if (gameManager.GetComponent<GameManager>().plantedSeed == null)
        {
            timer.SetActive(true);

            //telling GameManager what seedling you are working on
            gameManager.GetComponent<GameManager>().plantedSeed = seedling;
            groundToPlant.GetComponent<Ground>().PlantASeedling(seedling);
            notificationDisplayer.GetComponent<NotificationDisplayer>().PlantASeedling(seedling);
            Debug.Log("You have chosen " + seedling.itemName);
        }
        else if (gameManager.GetComponent<GameManager>().plantedSeed != seedling)
        {
            timer.SetActive(true);

            //telling GameManager what seedling you are working on
            gameManager.GetComponent<GameManager>().plantedSeed = seedling;
            groundToPlant.GetComponent<Ground>().PlantASeedling(seedling);
            notificationDisplayer.GetComponent<NotificationDisplayer>().PlantASeedling(seedling);
            Debug.Log("You have chosen " + seedling.itemName);
        }
        else if (gameManager.GetComponent<GameManager>().plantedSeed == seedling)
        {
            timer.SetActive(true);
        }
        else
        {
            Debug.Log("You arleady planted this seedling!");
        }
    }

    public Seed ReturnSeed()
    {
        return seedling;
    }
}
