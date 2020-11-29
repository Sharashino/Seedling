using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text playerCoinsText;

    [SerializeField]
    GameObject seedlingSelector;

    [Header("Player basic info")]
    public string playerName;
    public int playerCoins;
    public Seed plantedSeed;

    [Header("Player time spent on plants")]
    public int allTimeSpent;
    public int irisTimeSpent;
    public int roseTimeSpent;
    public int tulipTimeSpent;

    [Header("Player seeds unlocked")]
    public bool isIrisUnlocked;
    public bool isRoseUnlocked;
    public bool isTulipUnlocked;

    [Header("Player Trophies")]
    public bool isRichartUnlocked;
    public bool isSeedlerUnlocked;
    public bool isSupporterUnlocked;
    public bool isIndianaJohnesUnlocked;

    private void Start()
    {
        playerName = ES3.Load<string>("playerName");

        if(playerName == "xd")
        {
            isIndianaJohnesUnlocked = true;
        }

        playerCoins = ES3.Load<int>("playerCoins", 0);

        irisTimeSpent = ES3.Load("irisTimeSpent", 0);
        roseTimeSpent = ES3.Load("roseTimeSpent", 0);
        tulipTimeSpent = ES3.Load("tulipTimeSpent", 0);
        allTimeSpent = ES3.Load("allTimeSpent", 0);

        isIrisUnlocked = ES3.Load("isIrisUnlocked", false);
        isRoseUnlocked = ES3.Load("isRoseUnlocked", false);
        isTulipUnlocked = ES3.Load("isTulipUnlocked", false);

        isRichartUnlocked = ES3.Load("isRichartUnlocked", false);
        isSeedlerUnlocked = ES3.Load("isSeedlerUnlocked", false);
        isSupporterUnlocked = ES3.Load("isSupporterUnlocked", false);
        isIndianaJohnesUnlocked = ES3.Load("isIndianaJohnesUnlocked", false);

        playerCoinsText.text = playerCoins.ToString();
    }

    public void CheckForTrophy()
    {
        if(isIrisUnlocked && isRoseUnlocked && isTulipUnlocked)
        {
            isSeedlerUnlocked = true;
        }


    }

    public void UpdateCoins()
    {
        if(playerCoins >= 1000)
        {
            isRichartUnlocked = true;
        }

        playerCoinsText.text = playerCoins.ToString();
    }

    private void OnApplicationQuit()
    {
        ES3.Save("playerName", playerName);
        ES3.Save("playerCoins", playerCoins);

        ES3.Save("allTimeSpent", allTimeSpent);

        ES3.Save("irisTimeSpent", irisTimeSpent);
        ES3.Save("roseTimeSpent", roseTimeSpent);
        ES3.Save("tulipTimeSpent", tulipTimeSpent);

        ES3.Save("isIrisUnlocked", isIrisUnlocked);
        ES3.Save("isRoseUnlocked", isRoseUnlocked);
        ES3.Save("isTulipUnlocked", isTulipUnlocked);

        ES3.Save("isRichartUnlocked", isRichartUnlocked);
        ES3.Save("isSeedlerUnlocked", isSeedlerUnlocked);
        ES3.Save("isSupporterUnlocked", isSupporterUnlocked);
        ES3.Save("isIndianaJohnesUnlocked", isIndianaJohnesUnlocked);
    }
}
