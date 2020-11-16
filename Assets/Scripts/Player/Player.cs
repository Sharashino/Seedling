using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
public class Player : MonoBehaviour
{
    public string playerName;
    public int allTimeSpent;
    public int playerCoins;
    [SerializeField]
    TMP_Text playerCoinsText;

    public void SavePlayer()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        playerName = data.playerName;
        allTimeSpent = data.allTimeSpent;
        playerCoins = data.playerCoins;
        playerCoinsText.text = playerCoins.ToString();
    }
}
