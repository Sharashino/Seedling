using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image seedlingLogoImage;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Text niceToMeetYouText;
    [SerializeField] private GameObject inputGroup;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private float fadeSpeed = 0.01f;
    private bool hasRun;

    void Start()
    {
        hasRun = ES3.Load("hasRun", false);
        niceToMeetYouText.gameObject.SetActive(false);

        //if player has run game for the first
        if (!hasRun)
        {
            FirstGameRun();
        }
        else
        {
            AnotherGameRun();
        }
    }
    void Update()
    {
        NextButtonToggler();
    }

    private void FirstGameRun()
    {
        hasRun = true;
        ES3.Save("hasRun", true);
        ES3.Save("playerCoins", 100);
        StartCoroutine(FadeLogoImage());
    }

    private void AnotherGameRun()
    {
        var playerName = "xd";
        gameManager.playerName = ES3.LoadString("playerName", playerName);
        inputGroup.SetActive(false);
        niceToMeetYouText.text = "Welcome back " + gameManager.playerName + "!";
        StartCoroutine(FadeLogoAndText());
    }

    public void NextStage()
    {
        //Saving player name
        ES3.Save("playerName", nameInputField.text);
        inputGroup.SetActive(false);
        niceToMeetYouText.gameObject.SetActive(true);
        StartCoroutine(FadeWelcomeText());
    }

    IEnumerator FadeLogoAndText()
    {
        //wait 2 seconds before fading out
        yield return new WaitForSeconds(2);

        while (seedlingLogoImage.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            Color color = seedlingLogoImage.color;
            color.a -= fadeSpeed;
            seedlingLogoImage.color = color;
        }

        seedlingLogoImage.gameObject.SetActive(false);
        niceToMeetYouText.gameObject.SetActive(true);
        StartCoroutine(FadeWelcomeText());
    }

    IEnumerator FadeWelcomeText()
    {
        //wait 2 seconds before fading out
        yield return new WaitForSeconds(2);

        while (niceToMeetYouText.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            Color color = niceToMeetYouText.color;
            color.a -= fadeSpeed;
            niceToMeetYouText.color = color;
        }
        SceneManager.LoadScene("main");
    }

    IEnumerator FadeLogoImage()
    {
        //wait 2 seconds before fading out
        yield return new WaitForSeconds(2);

        while (seedlingLogoImage.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            Color color = seedlingLogoImage.color;
            color.a -= fadeSpeed;
            seedlingLogoImage.color = color;
        }
        seedlingLogoImage.gameObject.SetActive(false);
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
