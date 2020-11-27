using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LockPanel : MonoBehaviour
{
    Seed seedling;
    [SerializeField]
    TMP_Text coinsText;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject notificationDisplayer;
    [SerializeField]
    GameObject buttonPanel;
    [SerializeField]
    GameObject lockPanel;
    [SerializeField]
    TMP_Text requiredCoins;

    private void Start()
    {
        seedling = buttonPanel.GetComponent<DefineSeedling>().seedling;
        PanelLock();
        requiredCoins.text = seedling.coinsToUnlock.ToString();
    }

    public void UnlockPanel()
    {
        if (gameManager.playerCoins >= seedling.coinsToUnlock)
        {
            gameManager.playerCoins -= seedling.coinsToUnlock;
            switch (seedling.itemName)
            {
                case "Iris Seeds":
                    gameManager.isIrisUnlocked = true;
                    break;
                case "Rose Seeds":
                    gameManager.isRoseUnlocked = true;
                    break;
                case "Tulip Seeds":
                    gameManager.isTulipUnlocked = true;
                    break;
                default:
                    break;
            }

            seedling.isUnlocked = true;
            UpdateCoins();
            lockPanel.gameObject.SetActive(false);
            notificationDisplayer.GetComponent<NotificationDisplayer>().SeedlingUnlocked(seedling);
        }
        else
        {
            notificationDisplayer.GetComponent<NotificationDisplayer>().NotEnoughCoins();
        }
    }

    public void PanelLock()
    {
        if(!seedling.isUnlocked)
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
