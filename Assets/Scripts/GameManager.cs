using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public string playerName;
    public int allTimeSpent;
    public int playerCoins;
    [SerializeField]
    TMP_Text playerCoinsText;

    [SerializeField]
    GameObject seedlingSelector;

    [SerializeField]
    TMP_Text seedlingTime;

    public Seed plantedSeed;

    private void Start()
    {
        playerName = ES3.Load<string>("playerName");
        playerCoins = ES3.Load<int>("playerCoins");
        playerCoinsText.text = playerCoins.ToString();
    }
    private void SaveData()
    {
        ES3.Save<string>("playerCoins", playerName);
        ES3.Save<int>("allTimeSpent", allTimeSpent);
    }


    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveData();
        }
    }

   
   
}
