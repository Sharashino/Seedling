using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefineSeedling : MonoBehaviour
{
    [SerializeField]
    GameObject groundToPlant;

    [SerializeField]
    GameObject timer;

    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    GameObject seedlingSelector;

    [SerializeField]
    TMP_Text seedlingName;

    [SerializeField]
    TMP_Text seedlingTime;

    [SerializeField]
    TMP_Text seedlingCuriosity;

    [SerializeField]
    Image seedlingImage;

    public Seed seedling;

    // Start is called before the first frame update
    void Start()
    {
        seedlingName.text = seedling.itemName;
        seedlingTime.text = seedling.growInMinutes + " / " + seedling.minutesToGrow;
        seedlingCuriosity.text = seedling.seedlingCuriosity;
        seedlingImage.sprite = seedling.itemIcon;
    }

    public void ChoseSeedling()
    {
        timer.SetActive(true);
        seedlingSelector.SetActive(false);

        //telling GameManager what seedling you are working on
        gameManager.GetComponent<GameManager>().plantedSeed = seedling;
        groundToPlant.GetComponent<Ground>().PlantASeedling(seedling);
        Debug.Log("You have chosen " + seedling.itemName);
    }
}
