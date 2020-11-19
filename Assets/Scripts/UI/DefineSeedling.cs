using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefineSeedling : MonoBehaviour
{
    [SerializeField]
    GameObject timer;

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

    public void UpdateSeedlingTime()
    {
        seedlingTime.text = seedling.growInMinutes + " / " + seedling.minutesToGrow;
    }

    public void ChoseSeedling()
    {
        timer.SetActive(true);
        seedlingSelector.SetActive(false);

        //telling timer what seedling you are working on
        timer.GetComponent<CountdownTimer>().plantedSeedling = seedling;
        Debug.Log("You have chosen " + seedling.itemName);
    }
}
