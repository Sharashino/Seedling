using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float startingTime = 0f;
    [SerializeField] private GameObject timerButtons;
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private ParticleSystem growParticles;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SeedlingManager seedlingManager;
    [SerializeField] private NotificationDisplayer notificationDisplayer;
    [SerializeField] private GameObject seedlingSelector;

    private float timer;
    private int hours;
    private int minutes;
    private int seconds;

    private void Update()
    {
        currentTime = timer;
    }

    public void StartTimer()
    {
        if (currentTime != 0)
        {
            StartCoroutine(StartCountdown(timerButtons));
        }
    }

    public void AddTime()
    {
        //Adding to timer in seconds!!!
        timer += 60;
        FormatText();
    }

    public void SubtractTime()
    {
        //Subtracting timer in seconds!!!
        if (timer >= 2)
        {
            timer -= 60;
            FormatText();
        }
    }

    private IEnumerator StartCountdown(GameObject offButtons)
    {
        startingTime = timer / 60;
        offButtons.SetActive(false);

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            FormatText();
            yield return null;
        }

        offButtons.SetActive(true);

        //if player spent 1 minute on plant fix syntax
        if (startingTime == 1)
        {
            notificationDisplayer.TimeSpentOnSeedling(1, seedlingManager.GetCurrentSeedling());
            gameManager.allTimeSpent += 1;
            gameManager.playerCoins += 1;
            gameManager.UpdateCoins();

            //add one minute to a seedling you have planted
            switch (seedlingManager.GetCurrentSeedling().itemName)
            {
                case "Iris Seeds":
                    {
                        gameManager.irisTimeSpent += 120;

                        if (gameManager.irisTimeSpent >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                        }
                    }
                    break;
                case "Rose Seeds":
                    {
                        gameManager.roseTimeSpent += 1;

                        if (gameManager.roseTimeSpent >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                        }
                    }
                    break;
                case "Tulip Seeds":
                    {
                        gameManager.tulipTimeSpent += 1;
                        
                        if (gameManager.tulipTimeSpent >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            notificationDisplayer.TimeSpentOnSeedling((int)startingTime, seedlingManager.GetCurrentSeedling());
            gameManager.allTimeSpent += (int)startingTime;
            gameManager.playerCoins += (int)startingTime;
            gameManager.UpdateCoins();

            //add time to a seedling you have planted
            switch (seedlingManager.GetCurrentSeedling().itemName)
            {
                case "Iris Seeds":
                    {
                        gameManager.irisTimeSpent += (int)startingTime;
                        if (gameManager.irisTimeSpent >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                        }
                    }
                    break;
                case "Rose Seeds":
                    {
                        gameManager.roseTimeSpent += (int)startingTime;
                        if (gameManager.roseTimeSpent >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                        }
                    }
                    break;
                case "Tulip Seeds":
                    {
                        gameManager.tulipTimeSpent += (int)startingTime;
                        if (gameManager.tulipTimeSpent >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                        {
                            seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        //after done with timer update seedling selector timers and spawn particles
        seedlingSelector.GetComponentInChildren<DefineSeedling>().UpdatePanel();
        CreateGrowParticles();
        
        //reset the timer
        timer = 0;
    }

    private void CreateGrowParticles()
    {
        growParticles.Play();
    }

    private void FormatText()
    {
        hours = (int)(timer / 3600) % 24;
        minutes = (int)(timer / 60) % 60;
        seconds = (int)(timer % 60);

        countDownText.text = "";

        #region hours
        if (hours <= 9)
        {
            countDownText.text += "0" + hours + ":";
        }
        else if (hours >= 10)
        {
            countDownText.text += hours + ":";
        }
        else
        {
            countDownText.text += "00";
        }
        #endregion

        #region minutes
        if (minutes <= 9)
        {
            countDownText.text += "0" + minutes + ":";
        }
        else if (minutes >= 10)
        {
            countDownText.text += minutes + ":";

        }
        else
        {
            countDownText.text += "00";
        }
        #endregion

        #region seconds
        if (seconds <= 9)
        {
            countDownText.text += "0" + seconds;

        }
        else if (seconds >= 10)
        {
            countDownText.text += seconds;

        }
        else
        {
            countDownText.text += "00";
        }
        #endregion

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
