﻿using System.Collections;
using UnityEngine;
using TMPro;

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
        notifierText.text = "You have unlocked new " +trophyName + " trophy!";

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
        notifierText.text = "You have unlocked " + unlockedSeed.itemName + "!";
        
        StartCoroutine(FadeText());
    }

    public void PlantASeedling(Seed chosenSeedling)
    {
        notifier.SetActive(true);
        notifierText.text = "You have chosen to grow " + chosenSeedling.itemName + "!";
        
        StartCoroutine(FadeText());
    }

    public void TimeSpentOnSeedling(int timeSpent, Seed plantedSeedling)
    {
        notifier.SetActive(true);
        
        if(timeSpent == 1)
        {
            notifierText.text = "You have spent " + timeSpent + " minute on " + plantedSeedling.itemName + "!";
        }
        else
        {
            notifierText.text = "You have spent " + timeSpent + " minutes on " + plantedSeedling.itemName + "!";
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