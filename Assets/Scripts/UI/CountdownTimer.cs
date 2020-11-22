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
    GameManager gameManager;

    private void Update()
    {
        currentTime = timer;
    }

    public void StartTimer()
    {
        if(currentTime != 0)
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
        if(startingTime == 1)
        {
            Debug.Log("You spent " + startingTime + " minute on your " +gameManager.plantedSeed.itemName);
            gameManager.plantedSeed.playerTimeSpent += 1;
            gameManager.allTimeSpent += 1;
            gameManager.playerCoins += 1;
            gameManager.UpdateCoins();
        }
        else
        {
            Debug.Log("You spent " + startingTime + " minutes on your " +gameManager.plantedSeed.itemName);
            gameManager.plantedSeed.playerTimeSpent += (int)startingTime;
            gameManager.allTimeSpent += (int)startingTime;
            gameManager.playerCoins += (int)startingTime;
            gameManager.UpdateCoins();
        }
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
