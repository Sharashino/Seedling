using TMPro;
using UnityEngine;
using Seedling.SO;
using Seedling.Enums;
using Seedling.Seeds;
using Seedling.Managers;

namespace Seedling.UI
{
    public class LockPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text coinsText;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject notificationDisplayer;
        [SerializeField] private GameObject buttonPanel;
        [SerializeField] private GameObject lockPanel;
        [SerializeField] private TMP_Text requiredCoins;

        private SeedSO seedling;

        private void Start()
        {
            PanelLock();
            requiredCoins.text = seedling.coinsToUnlock.ToString();
        }

        private void UnlockPanel()
        {
            if (gameManager.PlayerCoins >= seedling.coinsToUnlock)
            {
                gameManager.PlayerCoins -= seedling.coinsToUnlock;

                switch (seedling.seedType)
                {
                    case SeedType.IrisSeed:
                        gameManager.isIrisUnlocked = true;
                        break;
                    case SeedType.RoseSeed:
                        gameManager.isRoseUnlocked = true;
                        break;
                    case SeedType.TulipSeed:
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
            switch (seedling.seedType)
            {
                case SeedType.IrisSeed:
                    {
                        if (gameManager.isIrisUnlocked)
                        {
                            lockPanel.gameObject.SetActive(false);
                        }
                        else
                        {
                            lockPanel.gameObject.SetActive(true);
                        }
                        break;
                    }
                case SeedType.RoseSeed:
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
                case SeedType.TulipSeed:
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
}