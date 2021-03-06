﻿using TMPro;
using UnityEngine;
using Seedling.SO;
using Seedling.UI;
using UnityEngine.UI;
using Seedling.Enums;
using Seedling.Managers;

namespace Seedling.Seeds
{
    public class DefineSeedling : MonoBehaviour
    {
        [SerializeField] private NotificationDisplayer notificationDisplayer;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private SeedlingManager seedlingManager;
        [SerializeField] private GameObject timer;
        [SerializeField] private GameObject seedlingSelector;
        [SerializeField] private TMP_Text seedlingName;
        [SerializeField] private TMP_Text seedlingTime;
        [SerializeField] private TMP_Text seedlingCuriosity;
        [SerializeField] private Image seedlingImage;
        [SerializeField] private Seed seedling;

        // Start is called before the first frame update
        void Start()
        {
            seedlingName.text = seedling.seedName;
            seedlingCuriosity.text = seedling.seedlingCuriosity;
            seedlingImage.sprite = seedling.seedIcon;

            switch (seedling.seedlingType)
            {
                case SeedlingType.IrisSeed:
                    seedlingTime.text = gameManager.IrisTimeSpent + " / " + seedling.minutesToGrow;
                    break;
                case SeedlingType.RoseSeed:
                    seedlingTime.text = gameManager.RoseTimeSpent + " / " + seedling.minutesToGrow;
                    break;
                case SeedlingType.TulipSeed:
                    seedlingTime.text = gameManager.TulipTimeSpent + " / " + seedling.minutesToGrow;
                    break;
                default:
                    break;
            }
        }

        public void UpdateSeedlingTimers()
        {
            switch (seedling.seedlingType)
            {
                case SeedlingType.IrisSeed:
                    seedlingTime.text = gameManager.IrisTimeSpent + " / " + seedling.minutesToGrow;
                    break;
                case SeedlingType.RoseSeed:
                    seedlingTime.text = gameManager.RoseTimeSpent + " / " + seedling.minutesToGrow;
                    break;
                case SeedlingType.TulipSeed:
                    seedlingTime.text = gameManager.TulipTimeSpent + " / " + seedling.minutesToGrow;
                    break;
                default:
                    break;
            }
        }

        public void ChoseSeedling()
        {
            if (seedlingManager.CurrentSeedling == null)
            {
                timer.SetActive(true);
                seedlingManager.CurrentSeedling = seedling;
                seedlingManager.PlantSeedling(seedling);
                notificationDisplayer.PlantedSeedling(seedling);
            }
            else if (seedlingManager.CurrentSeedling != seedling && !seedlingManager.IsReadyToHarvest)
            {
                timer.SetActive(true);
                seedlingManager.CurrentSeedling = seedling;
                seedlingManager.PlantSeedling(seedling);
                notificationDisplayer.PlantedSeedling(seedling);
            }
            else if (seedlingManager.CurrentSeedling == seedling && !seedlingManager.IsReadyToHarvest)
            {
                timer.SetActive(true);
                notificationDisplayer.YouPlantedThisArleady();
            }
            else if (seedlingManager.IsReadyToHarvest)
            {
                timer.SetActive(true);
                notificationDisplayer.HarvestReminder();
            }
            else
            {
                notificationDisplayer.YouPlantedThisArleady();
            }
        }

        public Seed Seedling
        {
            get
            {
                return seedling;
            }
        }
    }
}
