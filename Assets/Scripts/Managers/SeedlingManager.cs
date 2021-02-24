using TMPro;
using UnityEngine;
using Seedling.SO;
using Seedling.UI;
using Seedling.Enums;
using Seedling.Seeds;
using Seedling.Grounds;

namespace Seedling.Managers
{
    public class SeedlingManager : MonoBehaviour
    {
        [SerializeField] private Seed currentSeedling;
        [SerializeField] private Ground seedlingGround;
        [SerializeField] private DefineSeedling defineSeedling;
        [SerializeField] private NotificationDisplayer notificationDisplayer;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TimeManager timeManager;
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private GameObject seedlingSelector;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private bool isReadyToHarvest;

        public void PlantSeedling(Seed seedlingToPlant)
        {
            seedlingGround.PlantASeedling(seedlingToPlant);
            audioManager.PlaySound(SoundType.PlantSeedling);
        }

        public void DoneGrowing()
        {
            audioManager.PlaySound(SoundType.DoneGrowing);
        }

        public void GrowFlower(Seed seedlingToGrow)
        {
            seedlingToGrow.isDoneGrowing = true;
            currentSeedling.seedObject.GetComponent<SeedlingMB>().GrowFlower(currentSeedling.seedObject, seedlingGround.gameObject);
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
                        gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.harvestCoins;
                    }
                    break;
                case FlowerType.RoseFlower:
                    {
                        gameManager.RoseTimeSpent = 0;
                        gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.harvestCoins;

                    }
                    break;
                case FlowerType.TulipFlower:
                    {
                        gameManager.TulipTimeSpent = 0;
                        gameManager.PlayerCoins = flowerToHarvest.FlowerSeedling.harvestCoins;
                    }
                    break;
                default:
                    break;
            }

            notificationDisplayer.HarvestFlower(flowerToHarvest.GetComponent<Flower>());

            currentSeedling.isDoneGrowing = false;
            flowerToHarvest.HarvestFlower(flowerToHarvest.gameObject);

            currentSeedling = null;
            IsReadyToHarvest = false;
            gameManager.UpdateCoins();
            timeManager.TimerButtons = false;
            audioManager.PlaySound(SoundType.HarvestSeedling);
        }


        public bool IsReadyToHarvest
        {
            get
            {
                return isReadyToHarvest;
            }
            set
            {
                isReadyToHarvest = value;
            }
        }

        public Seed CurrentSeedling
        {
            get
            {
                return currentSeedling;
            }
            set
            {
                currentSeedling = value;
            }
        }

        public DefineSeedling DefineSeedling
        {
            get
            {
                return defineSeedling;
            }
        }
    }
}

