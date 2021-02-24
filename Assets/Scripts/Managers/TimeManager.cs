using TMPro;
using UnityEngine;
using Seedling.Enums;

namespace Seedling.Managers
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private SeedlingManager seedlingManager;
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
            switch (seedlingManager.CurrentSeedling.seedlingType)
            {
                case SeedlingType.IrisSeed:
                    {
                        gameManager.IrisTimeSpent += time;

                        if (gameManager.IrisTimeSpent >= seedlingManager.CurrentSeedling.minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.CurrentSeedling);
                        }
                    }
                    break;
                case SeedlingType.RoseSeed:
                    {
                        gameManager.RoseTimeSpent += time;

                        if (gameManager.RoseTimeSpent >= seedlingManager.CurrentSeedling.minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.CurrentSeedling);
                        }
                    }
                    break;
                case SeedlingType.TulipSeed:
                    {
                        gameManager.TulipTimeSpent += time;

                        if (gameManager.TulipTimeSpent >= seedlingManager.CurrentSeedling.minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.CurrentSeedling);
                        }
                    }
                    break;
                default:
                    break;
            }

            seedlingManager.DefineSeedling.UpdateSeedlingTimers();
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
