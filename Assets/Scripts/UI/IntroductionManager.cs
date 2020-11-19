using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    Image bigImage;
    [SerializeField]
    TMP_InputField nameInputField;
    [SerializeField]
    TMP_Text niceToMeetYouText;
    [SerializeField]
    GameObject inputGroup;
    [SerializeField]
    GameObject nextButton;

    TouchScreenKeyboard keyboard;
    public TMP_Text text;
    public string keyboardText;

    //fading object speed
    float fadeSpeed = 0.01f;

    bool hasRun = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime());
        niceToMeetYouText.gameObject.SetActive(false);

        GiveCoins();
    }

    private void GiveCoins()
    {
        if(!hasRun)
        {
            player.playerCoins += 100;
            hasRun = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        NextButtonToggler();

        if(TouchScreenKeyboard.visible == false && keyboard != null)
        {
            if(keyboard.status == TouchScreenKeyboard.Status.Visible)
            {
                keyboardText = keyboard.text;
                text.text = "Hello " + keyboardText;
                keyboard = null;
            }
        }
    }

    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open(" ", TouchScreenKeyboardType.Default);
    }

    public void NextStage()
    {
        player.playerName = nameInputField.text;
        SaveSystem.SaveData(player);
        inputGroup.SetActive(false);
        LastStage();
    }

    private void LastStage()
    {
        niceToMeetYouText.gameObject.SetActive(true);
        StartCoroutine(WaitTime());
    }

    IEnumerator FadeText()
    {
        while(niceToMeetYouText.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            Color color = niceToMeetYouText.color;
            color.a -= fadeSpeed;
            niceToMeetYouText.color = color;
        }
        SceneManager.LoadScene("main");
    }

    //Wait 2 sec with seedling logo then fade it away
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);

        if(inputGroup.activeSelf)
        {
            StartCoroutine(FadeImage());
        }
        else
        {
            StartCoroutine(FadeText());
        }
    }

    //Fade out seedling logo image
    IEnumerator FadeImage()
    {
        while (bigImage.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            Color color = bigImage.color;
            color.a -= fadeSpeed;
            bigImage.color = color;
        }
        bigImage.gameObject.SetActive(false);
    }

    //Toggle next button off when input field is empty
    private void NextButtonToggler()
    {
        if (nameInputField.text == "")
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
}
