using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefineSeedling : MonoBehaviour
{
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

    public Seeds seedling;


    // Start is called before the first frame update
    void Start()
    {
        seedlingName.text = seedling.itemName;
        seedlingTime.text = "0 / " + seedling.minutesToGrow;
        seedlingCuriosity.text = seedling.seedlingCuriosity;
        seedlingImage.sprite = seedling.itemIcon;
    }

    public void ChoseSeedling()
    {
        seedlingSelector.SetActive(false);
        Debug.Log("You have chosen " + seedling.itemName);
    }
}
