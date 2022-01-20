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


        public SeedSO CurrentSeed { get => currentSeed; set => currentSeed = value; }
        public DefineSeedling DefineSeed { get => defineSeed; set => defineSeed = value; }
        public bool IsReadyToHarvest { get => isReadyToHarvest; set => isReadyToHarvest = value; }

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
    }
}

