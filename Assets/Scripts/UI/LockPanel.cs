using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LockPanel : MonoBehaviour
{
    Seed seeds;
    [SerializeField]
    TMP_Text coinsText;
    [SerializeField]
    Player player;
    public bool isLocked;
    [SerializeField]
    GameObject buttonPanel;
    [SerializeField]
    GameObject lockPanel;
    [SerializeField]
    TMP_Text requiredCoins;

    private void Start()
    {
        isLocked = true;
        PanelLock();
        seeds = buttonPanel.GetComponent<DefineSeedling>().seedling;
        requiredCoins.text = seeds.coinsToUnlock.ToString();
    }

    public void UnlockPanel()
    {
        if (player.playerCoins >= seeds.coinsToUnlock)
        {
            player.playerCoins -= seeds.coinsToUnlock;
            UpdateCoins();
            lockPanel.gameObject.SetActive(false);
            Debug.Log("You have unlocked " +gameObject.GetComponent<DefineSeedling>().seedling.itemName);
        }
        else
        {
            Debug.Log("You dont have enough coins");
        }
    }

    public void PanelLock()
    {
        if(isLocked)
        {
            lockPanel.gameObject.SetActive(true);
        }
        else
        {
            lockPanel.gameObject.SetActive(false);
        }
    }
    private void UpdateCoins()
    {
        coinsText.text = player.playerCoins.ToString();
    }

}
