using TMPro;
using UnityEngine;
using Seedling.SO;
using Seedling.UI;
using Seedling.Enums;
using Seedling.Seeds;
using Seedling.Grounds;
using System;

namespace Seedling.Managers
{
    public class SeedManager : MonoBehaviour
    {
        #region Singleton

        private static SeedManager _instance = null;
        public static SeedManager Instance
        {
            get
            {
                if (_instance == null) Debug.LogError("[GameManager-Static] No Game Manager on the scene!");
                return _instance;
            }
            private set => _instance = value;
        }

        #endregion

        public bool HasCurrentSeed => currentSeed != null;

        [SerializeField] private SeedSO currentSeed;
        [SerializeField] private Ground seedlingGround;
        [SerializeField] private DefineSeedling defineSeed;
        [SerializeField] private NotificationDisplayer notificationDisplayer;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TimeManager timeManager;
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private GameObject seedlingSelector;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private bool isReadyToHarvest;
        public static Action onFlowerHarvest;


        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
            }
        }

        public void PlantSeed(SeedSO seed)
        {
            //seedlingGround.PlantASeedling(seedlingToPlant);
            //audioManager.PlaySound(SoundType.PlantSeedling);
        }

        public void DoneGrowing()
        {
            audioManager.PlaySound(SoundType.DoneGrowing);
        }

        public void GrowFlower(SeedSO seedlingToGrow)
        {
            //seedlingToGrow.isDoneGrowing = true;
            notificationDisplayer.GrowSeedling(seedlingToGrow);
            audioManager.PlaySound(SoundType.DoneGrowing);
            isReadyToHarvest = true;
        }

        public void HarvestFlower(Flower flowerToHarvest)
        {
            switch (flowerToHarvest.FlowerType)
            {
                case FlowerType.IrisFlower:
                    {
                        gameManager.IrisTimeSpent = 0;
                        gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.coinsForPlanting;
                    }
                    break;
                case FlowerType.RoseFlower:
                    {
                        gameManager.RoseTimeSpent = 0;
                        gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.coinsForPlanting;

                    }
                    break;
                case FlowerType.TulipFlower:
                    {
                        gameManager.TulipTimeSpent = 0;
                        gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.coinsForPlanting;
                    }
                    break;
                default:
                    break;
            }

            notificationDisplayer.HarvestFlower(flowerToHarvest.GetComponent<Flower>());

            //currentSeed.isDoneGrowing = false;
            //flowerToHarvest.HarvestFlower(flowerToHarvest.gameObject);

            currentSeed = null;
            IsReadyToHarvest = false;
            gameManager.UpdateCoins();
            timeManager.TimerButtons = false;
            audioManager.PlaySound(SoundType.HarvestSeedling);
        }


        public SeedSO CurrentSeed
        {
            get => currentSeed; set
            {
                Debug.Log($"Current seed - {value.seedName}");
                currentSeed = value;
            }
        }
        public DefineSeedling DefineSeed
        {
            get => defineSeed; set
            {
                defineSeed = value;
            }
        }
        public bool IsReadyToHarvest { get => isReadyToHarvest; set => isReadyToHarvest = value; }
    }
}

