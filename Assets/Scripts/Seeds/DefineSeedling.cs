using TMPro;
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
        [SerializeField] private SeedManager seedlingManager;
        [SerializeField] private GameObject timer;
        [SerializeField] private GameObject seedlingSelector;
        [SerializeField] private TMP_Text seedlingName;
        [SerializeField] private TMP_Text seedlingTime;
        [SerializeField] private TMP_Text seedlingCuriosity;
        [SerializeField] private Image seedlingImage;
        [SerializeField] private SeedSO seedling;

        // Start is called before the first frame update
        void Start()
        {
            seedlingName.text = seedling.seedName;
            seedlingCuriosity.text = seedling.seedCuriosity;
            seedlingImage.sprite = seedling.seedIcon;

            UpdateSeedlingTimers();
        }

        public void UpdateSeedlingTimers()
        {
            switch (seedling.seedType)
            {
                case SeedType.IrisSeed:
                    seedlingTime.text = gameManager.IrisTimeSpent + " / " + seedling.growTime;
                    break;
                case SeedType.RoseSeed:
                    seedlingTime.text = gameManager.RoseTimeSpent + " / " + seedling.growTime;
                    break;
                case SeedType.TulipSeed:
                    seedlingTime.text = gameManager.TulipTimeSpent + " / " + seedling.growTime;
                    break;
                default:
                    break;
            }
        }

        public void ChoseSeedling()
        {
            if (seedlingManager.CurrentSeed == null)
            {
                timer.SetActive(true);
                seedlingManager.CurrentSeed = seedling;
                seedlingManager.PlantSeed(seedling);
                notificationDisplayer.PlantedSeedling(seedling);
            }
            else if (seedlingManager.CurrentSeed != seedling && !seedlingManager.IsReadyToHarvest)
            {
                timer.SetActive(true);
                seedlingManager.CurrentSeed = seedling;
                seedlingManager.PlantSeed(seedling);
                notificationDisplayer.PlantedSeedling(seedling);
            }
            else if (seedlingManager.CurrentSeed == seedling && !seedlingManager.IsReadyToHarvest)
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

        public SeedSO Seedling
        {
            get
            {
                return seedling;
            }
        }
    }
}
