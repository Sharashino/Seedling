using TMPro;
using UnityEngine;
using Seedling.SO;
using Seedling.Enums;
using Seedling.Seeds;
using Seedling.Managers;

namespace Seedling.UI.Menu
{
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

                switch (seedling.seedlingType)
                {
                    case SeedlingType.IrisSeed:
                        gameManager.isIrisUnlocked = true;
                        break;
                    case SeedlingType.RoseSeed:
                        gameManager.isRoseUnlocked = true;
                        break;
                    case SeedlingType.TulipSeed:
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
            switch (seedling.seedlingType)
            {
                case SeedlingType.IrisSeed:
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
                case SeedlingType.RoseSeed:
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
                case SeedlingType.TulipSeed:
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