using TMPro;
using UnityEngine;
using Seedling.SO;
using Seedling.Seeds;
using Seedling.Managers;
using System.Collections;

namespace Seedling.UI
{
    public class NotificationDisplayer : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject notifier;
        [SerializeField] private TMP_Text notifierText;
        private float fadeSpeed = 0.02f;

        void Start()
        {
            notifier.SetActive(false);
        }

        public void TrophyUnlocked(string trophyName)
        {
            notifier.SetActive(true);
            notifierText.text = "You have unlocked new " + trophyName + " trophy!";

            StartCoroutine(FadeText());
        }

        public void NotEnoughCoins()
        {
            notifier.SetActive(true);
            notifierText.text = "You dont have enough coins!";

            StartCoroutine(FadeText());
        }

        public void SeedlingUnlocked(Seed unlockedSeed)
        {
            notifier.SetActive(true);
            notifierText.text = "You have unlocked " + unlockedSeed.seedName + "!";

            StartCoroutine(FadeText());
        }

        public void PlantedSeedling(Seed chosenSeedling)
        {
            notifier.SetActive(true);
            notifierText.text = "You have chosen to grow " + chosenSeedling.seedName + "!";

            StartCoroutine(FadeText());
        }

        internal void PlantSeedlingFirst()
        {
            notifier.SetActive(true);
            notifierText.text = "You need to plant a seedling first!";

            StartCoroutine(FadeText());
        }

        public void GrowSeedling(Seed grownSeedling)
        {
            notifier.SetActive(true);
            notifierText.text = "Your " + grownSeedling.seedName + " has grown up!";

            StartCoroutine(FadeText());
        }

        public void YouPlantedThisArleady()
        {
            notifier.SetActive(true);
            notifierText.text = "You are grownig this seedling already!";

            StartCoroutine(FadeText());
        }

        public void WaitTillTimerDone()
        {
            notifier.SetActive(true);
            notifierText.text = "Focus on your task! Wait till your timer is done!";

            StartCoroutine(FadeText());
        }

        public void HarvestFlower(Flower flowerToHarvest)
        {
            notifier.SetActive(true);
            notifierText.text = "You have harvested " + flowerToHarvest.FlowerName + "!";

            StartCoroutine(FadeText());
        }

        public void HarvestReminder()
        {
            notifier.SetActive(true);
            notifierText.text = "You need to harvest your flower first!";

            StartCoroutine(FadeText());
        }

        public void TimeSpentOnSeedling(int timeSpent, Seed plantedSeedling)
        {
            notifier.SetActive(true);

            if (timeSpent == 1)
            {
                notifierText.text = "You have spent " + timeSpent + " minute on " + plantedSeedling.seedName + "!";
            }
            else
            {
                notifierText.text = "You have spent " + timeSpent + " minutes on " + plantedSeedling.seedName + "!";
            }

            StartCoroutine(FadeText());
        }

        private IEnumerator FadeText()
        {
            //wait 2 seconds before fading out
            yield return new WaitForSeconds(2);

            //variable for fading out text color
            Color color;
            color = notifierText.color;

            while (notifierText.color.a > 0)
            {
                yield return new WaitForEndOfFrame();
                color.a -= fadeSpeed;
                notifierText.color = color;
            }

            notifier.SetActive(false);
            color.a = 1;
            notifierText.color = color;
        }
    }
}