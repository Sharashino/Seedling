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
    GameManager gameManager;
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
        if (gameManager.playerCoins >= seeds.coinsToUnlock)
        {
            gameManager.playerCoins -= seeds.coinsToUnlock;
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
        coinsText.text = gameManager.playerCoins.ToString();
    }

}
