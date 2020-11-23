using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public string playerName;
    public int playerCoins;

    [Header("Player time spent on plants")]
    public int allTimeSpent;
    public int irisTimeSpent;
    public int roseTimeSpent;
    public int tulipTimeSpent;

    [Header("Player seeds unlocked")]
    public bool isIrisUnlocked;
    public bool isRoseUnlocked;
    public bool isTulipUnlocked;

    public Seed plantedSeed;

    [SerializeField]
    TMP_Text playerCoinsText;

    [SerializeField]
    GameObject seedlingSelector;


    private void Start()
    {
        playerName = ES3.Load<string>("playerName");
        playerCoins = ES3.Load("playerCoins", 0);

        irisTimeSpent = ES3.Load("irisTimeSpent", 0);
        roseTimeSpent = ES3.Load("roseTimeSpent", 0);
        tulipTimeSpent = ES3.Load("tulipTimeSpent", 0);
        allTimeSpent = ES3.Load("allTimeSpent", 0);

        isIrisUnlocked = ES3.Load("isIrisUnlocked", false);
        isRoseUnlocked = ES3.Load("isRoseUnlocked", false);
        isTulipUnlocked = ES3.Load("isTulipUnlocked", false);


        playerCoinsText.text = playerCoins.ToString();
    }

    public void UpdateCoins()
    {
        playerCoinsText.text = playerCoins.ToString();
    }

    private void OnApplicationQuit()
    {
        ES3.Save("playerCoins", playerName);
        ES3.Save("allTimeSpent", allTimeSpent);
        ES3.Save("irisTimeSpent", irisTimeSpent);
        ES3.Save("roseTimeSpent", roseTimeSpent);
        ES3.Save("tulipTimeSpent", tulipTimeSpent);
        ES3.Save("isIrisUnlocked", isIrisUnlocked);
        ES3.Save("isRoseUnlocked", isRoseUnlocked);
        ES3.Save("isTulipUnlocked", isTulipUnlocked);
        ES3.Save("allTimeSpent", allTimeSpent);
    }



}
