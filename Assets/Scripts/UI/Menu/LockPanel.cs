using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject notificationDisplayer;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private GameObject lockPanel;
    [SerializeField] private TMP_Text requiredCoins;

    private Seed seedling;

    private void Start()
    {
        seedling = buttonPanel.GetComponent<DefineSeedling>().Seedling;
        PanelLock();
        requiredCoins.text = seedling.coinsToUnlock.ToString();
    }

    private void UnlockPanel()
    {
        if (gameManager.PlayerCoins >= seedling.coinsToUnlock)
        {
            gameManager.PlayerCoins -= seedling.coinsToUnlock;

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
            gameManager.GetComponent<GameManager>().CheckForTrophy();
        }
        else
        {
            notificationDisplayer.GetComponent<NotificationDisplayer>().NotEnoughCoins();
        }
    }

    private void PanelLock()
    {
        switch (seedling.itemName)
        {
            case "Iris Seeds":
                {
                    if(gameManager.isIrisUnlocked)
                    {
                        lockPanel.gameObject.SetActive(false);
                    }
                    else
                    {
                        lockPanel.gameObject.SetActive(true);
                    }
                    break;
                }
            case "Rose Seeds":
                {
                    if (gameManager.isRoseUnlocked)
                    {
                        lockPanel.gameObject.SetActive(false);
                    }
                    else
                    {
                        lockPanel.gameObject.SetActive(true);
                    }
                    break;
                }
            case "Tulip Seeds":
                {
                    if (gameManager.isTulipUnlocked)
                    {
                        lockPanel.gameObject.SetActive(false);
                    }
                    else
                    {
                        lockPanel.gameObject.SetActive(true);
                    }
                    break;
                }
            default:
                break;
        }
    }

    private void UpdateCoins()
    {
        coinsText.text = gameManager.PlayerCoins.ToString();
    }
}
