using TMPro;
using UnityEngine;
using Seedling.Enums;

namespace Seedling.Managers
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private SeedManager seedlingManager;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject timerButtons;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private bool isCounting;

        private void Update()
        {
            if (isCounting)
            {
                timerButtons.SetActive(false);
            }
            else
            {
                timerButtons.SetActive(true);
            }
        }

        public void SetSeedlingSpentTime(int time)
        {
            switch (seedlingManager.CurrentSeed.seedType)
            {
                case SeedType.IrisSeed:
                    {
                        gameManager.IrisTimeSpent += time;

                        if (gameManager.IrisTimeSpent >= seedlingManager.CurrentSeed.growTime)
                        {
                            seedlingManager.GrowFlower(seedlingManager.CurrentSeed);
                        }
                    }
                    break;
                case SeedType.RoseSeed:
                    {
                        gameManager.RoseTimeSpent += time;

                        if (gameManager.RoseTimeSpent >= seedlingManager.CurrentSeed.growTime)
                        {
                            seedlingManager.GrowFlower(seedlingManager.CurrentSeed);
                        }
                    }
                    break;
                case SeedType.TulipSeed:
                    {
                        gameManager.TulipTimeSpent += time;

                        if (gameManager.TulipTimeSpent >= seedlingManager.CurrentSeed.growTime)
                        {
                            seedlingManager.GrowFlower(seedlingManager.CurrentSeed);
                        }
                    }
                    break;
                default:
                    break;
            }

            seedlingManager.DefineSeed.UpdateSeedlingTimers();
        }

        public bool IsCounting
        {
            get
            {
                return isCounting;
            }
            set
            {
                isCounting = value;
            }
        }

        public bool TimerButtons
        {
            get
            {
                return timerButtons;
            }
            set
            {
                timerButtons.SetActive(value);
            }
        }
    }
}
