using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public string playerName;
    public int allTimeSpent;
    public int playerCoins;

    public PlayerData(Player player)
    {
        playerName = player.playerName;
        allTimeSpent = player.allTimeSpent;
        playerCoins = player.playerCoins;
    }
}

