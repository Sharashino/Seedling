using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    int hours;
    int minutes;
    int seconds;

    [SerializeField]
    float currentTime = 0f;
    [SerializeField]
    float startingTime = 0f;
    float timer;

    public GameObject timerButtons;

    [SerializeField]
    TMP_Text countDownText;
    [SerializeField]
    ParticleSystem growParticles;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    NotificationDisplayer notificationDisplayer;
    [SerializeField]
    GameObject seedlingSelector;
    [SerializeField]
    Ground seedlingGround;
    private void Update()
    {
        currentTime = timer;
    }

    public void StartTimer()
    {
        if(currentTime != 0)
        {
            //If player can harvest his plant show notification and dont start the timer
            switch (gameManager.plantedSeed.itemName)
            {
                case "Iris Seeds":
                    {
                        if(gameManager.irisTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.HarvestPlant(gameManager.plantedSeed);
                            break;
                        }
                        else
                        {
                            StartCoroutine(StartCountdown(timerButtons));
                            break;
                        }
                    }
                case "Rose Seeds":
                    {
                        if (gameManager.roseTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.HarvestPlant(gameManager.plantedSeed);
                            break;
                        }
                        else
                        {
                            StartCoroutine(StartCountdown(timerButtons));
                            break;
                        }
                    }
                case "Tulip Seeds":
                    {
                        if (gameManager.roseTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.HarvestPlant(gameManager.plantedSeed);
                            break;
                        }
                        else
                        {
                            StartCoroutine(StartCountdown(timerButtons));
                            break;
                        }
                    }
                default:
                    break;
            }
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
        if(startingTime == 1)
        {
            gameManager.allTimeSpent += 1;
            gameManager.playerCoins += 1;
            gameManager.UpdateCoins();

            //add one minute to a seedling you have planted 
            //if current time spent = seedling time to harvest display notification
            switch (gameManager.plantedSeed.itemName)
            {
                case "Iris Seeds":
                    {
                        gameManager.irisTimeSpent += 1;
                        if (gameManager.irisTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.PlantReadyToHarvest(gameManager.plantedSeed);
                            gameManager.plantedSeed.canBeHarvested = true;
                            gameManager.plantedSeed.itemObject.GetComponent<Flower>().GrowFlower(seedlingGround.newSeedling);
                        }
                        else
                        {
                            notificationDisplayer.TimeSpentOnSeedling(1, gameManager.plantedSeed);
                        }
                    }
                    break;
                case "Rose Seeds":
                    {
                        gameManager.roseTimeSpent += 1;
                        if (gameManager.roseTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.PlantReadyToHarvest(gameManager.plantedSeed);
                            gameManager.plantedSeed.canBeHarvested = true;
                            gameManager.plantedSeed.itemObject.GetComponent<Flower>().GrowFlower(seedlingGround.newSeedling);
                        }
                        else
                        {
                            notificationDisplayer.TimeSpentOnSeedling(1, gameManager.plantedSeed);
                        }
                    }
                    break;
                case "Tulip Seeds":
                    {
                        gameManager.tulipTimeSpent += 1;
                        if (gameManager.tulipTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.PlantReadyToHarvest(gameManager.plantedSeed);
                            gameManager.plantedSeed.canBeHarvested = true;
                            gameManager.plantedSeed.itemObject.GetComponent<Flower>().GrowFlower(seedlingGround.newSeedling);
                        }
                        else
                        {
                            notificationDisplayer.TimeSpentOnSeedling(1, gameManager.plantedSeed);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            notificationDisplayer.TimeSpentOnSeedling((int)startingTime, gameManager.plantedSeed);
            gameManager.allTimeSpent += (int)startingTime;
            gameManager.playerCoins += (int)startingTime;
            gameManager.UpdateCoins();

            //add fixedTime to a seedling you have planted and show notification
            switch (gameManager.plantedSeed.itemName)
            {
                case "Iris Seeds":
                    {
                        gameManager.irisTimeSpent += (int)startingTime;
                        if (gameManager.irisTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.PlantReadyToHarvest(gameManager.plantedSeed);
                            gameManager.plantedSeed.canBeHarvested = true;
                            gameManager.plantedSeed.itemObject.GetComponent<Flower>().GrowFlower(gameManager.plantedSeed.itemObject);
                        }
                        else
                        {
                            notificationDisplayer.TimeSpentOnSeedling((int)startingTime, gameManager.plantedSeed);
                        }
                    }
                    break;
                case "Rose Seeds":
                    {
                        gameManager.roseTimeSpent += (int)startingTime;
                        if (gameManager.roseTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.PlantReadyToHarvest(gameManager.plantedSeed);
                            gameManager.plantedSeed.canBeHarvested = true;
                            gameManager.plantedSeed.itemObject.GetComponent<Flower>().GrowFlower(gameManager.plantedSeed.itemObject);
                        }
                        else
                        {
                            notificationDisplayer.TimeSpentOnSeedling((int)startingTime, gameManager.plantedSeed);
                        }
                    }
                    break;
                case "Tulip Seeds":
                    {
                        gameManager.tulipTimeSpent += (int)startingTime;
                        if (gameManager.tulipTimeSpent >= gameManager.plantedSeed.minutesToGrow)
                        {
                            notificationDisplayer.PlantReadyToHarvest(gameManager.plantedSeed);
                            gameManager.plantedSeed.canBeHarvested = true;
                            gameManager.plantedSeed.itemObject.GetComponent<Flower>().GrowFlower(gameManager.plantedSeed.itemObject);
                        }
                        else
                        {
                            notificationDisplayer.TimeSpentOnSeedling((int)startingTime, gameManager.plantedSeed);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        
        //after done with timer update seedling selector timers 
        //spawn particles and reset timer 
        seedlingSelector.GetComponentInChildren<DefineSeedling>().UpdatePanel();
        growParticles.Play();
        timer = 0;
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
            countDownText.text += "0" +hours + ":"; 
        }
        else if(hours >= 10)
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
        else if(minutes >= 10)
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
        else if(seconds >= 10)
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
