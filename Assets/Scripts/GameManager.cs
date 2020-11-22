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
    public int irisTimeSpent;
    public int roseTimeSpent;
    public int tulipTimeSpent;

    public Seed plantedSeed;

    [SerializeField]
    TMP_Text playerCoinsText;

    [SerializeField]
    GameObject seedlingSelector;


    private void Start()
    {
        playerName = ES3.Load<string>("playerName");
        playerCoins = ES3.Load<int>("playerCoins");
        //irisTimeSpent = ES3.Load<int>("irisTimeSpent");
        //roseTimeSpent = ES3.Load<int>("roseTimeSpent");
        //tulipTimeSpent = ES3.Load<int>("tulipTimeSpent");

        //playerCoinsText.text = playerCoins.ToString();
    }

    public void UpdateCoins()
    {
        playerCoinsText.text = playerCoins.ToString();
    }

    private void SaveData()
    {
        ES3.Save("playerCoins", playerName);
        ES3.Save("allTimeSpent", allTimeSpent);
        //ES3.Save("irisTimeSpent", irisTimeSpent);
        //ES3.Save("roseTimeSpent", roseTimeSpent);
        //ES3.Save("tulipTimeSpent", tulipTimeSpent);
    }


    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveData();
        }
    }

   
   
}
