using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SlideTrophyPanel : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject trophyPanel;
    [SerializeField]
    Image trophyImage;
    [SerializeField]
    TMP_Text trophyName;
    [SerializeField]
    TMP_Text trophyDesc;
    public void ShowHideTrophyPanel()
    {
        if (trophyPanel != null)
        {
            Animator panelTrophyAnimator = trophyPanel.GetComponent<Animator>();
            //Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();

            if (panelTrophyAnimator != null)
            {
                bool isTrophyPanelOpen = panelTrophyAnimator.GetBool("showTrophyPanel");

                panelTrophyAnimator.SetBool("showTrophyPanel", !isTrophyPanelOpen);
            }
        }
    }

    public void DefineShowTrophyPanel(Button clickedButton) 
    {
        var Trophy = clickedButton.GetComponent<DefineTrophy>();
        trophyImage.sprite = clickedButton.GetComponent<Image>().sprite;
        trophyDesc.text = Trophy.trophyDesc;

        //here we re switching trophy name to show ??? when Trophy locked and its name when unlocked
        switch (Trophy.trophyName)
        {
            case "Richart":
                if(gameManager.isRichartUnlocked)
                {
                    trophyName.text = Trophy.trophyName;
                }
                else
                {
                    trophyName.text = "???";
                }
                break;
            case "Seedler":
                if (gameManager.isSeedlerUnlocked)
                {
                    trophyName.text = Trophy.trophyName;
                }
                else
                {
                    trophyName.text = "???";
                }
                break;
            case "Supporter":
                if (gameManager.isSupporterUnlocked)
                {
                    trophyName.text = Trophy.trophyName;
                }
                else
                {
                    trophyName.text = "???";
                }
                break;
            case "Indiana Johnes":
                if (gameManager.isIndianaJohnesUnlocked)
                {
                    trophyName.text = Trophy.trophyName;
                }
                else
                {
                    trophyName.text = "???";
                }
                break;
            default:
                break;
        }
    }
}