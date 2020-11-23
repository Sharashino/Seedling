using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NotificationDisplayer : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject notifier;
    [SerializeField]
    TMP_Text notifierText;

    float fadeSpeed = 0.02f;

    void Start()
    {
        notifier.SetActive(false);
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

    IEnumerator FadeText()
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
