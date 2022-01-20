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
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject notifier;
        [SerializeField] private TMP_Text notifierText;

        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.Disable();
        }


        public void DisplayNotification(string text, float showTime)
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = text;
            canvasGroup.FadeOutCanvas(showTime);
        }

        public void TrophyUnlocked(string trophyName)
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You have unlocked new " + trophyName + " trophy!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void NotEnoughCoins()
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You dont have enough coins!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void SeedlingUnlocked(SeedSO unlockedSeed)
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You have unlocked " + unlockedSeed.seedName + "!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void PlantedSeedling(SeedSO chosenSeedling)
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You have chosen to grow " + chosenSeedling.seedName + "!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        internal void PlantSeedlingFirst()
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You need to plant a seedling first!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void GrowSeedling(SeedSO grownSeedling)
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "Your " + grownSeedling.seedName + " has grown up!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void YouPlantedThisArleady()
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You are grownig this seedling already!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void WaitTillTimerDone()
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "Focus on your task! Wait till your timer is done!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void HarvestFlower(Flower flowerToHarvest)
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You have harvested " + flowerToHarvest.FlowerName + "!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void HarvestReminder()
        {
            canvasGroup.FadeInCanvas();
            notifierText.text = "You need to harvest your flower first!";
            canvasGroup.FadeOutCanvas(2.5f);
        }

        public void TimeSpentOnSeedling(int timeSpent, SeedSO plantedSeedling)
        {
            canvasGroup.FadeInCanvas();

            if (timeSpent == 1)
            {
                notifierText.text = "You have spent " + timeSpent + " minute on " + plantedSeedling.seedName + "!";
            }
            else
            {
                notifierText.text = "You have spent " + timeSpent + " minutes on " + plantedSeedling.seedName + "!";
            }
            canvasGroup.FadeOutCanvas(2.5f);
        }
    }
}