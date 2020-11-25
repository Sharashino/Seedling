using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlideTrophyBar : MonoBehaviour
{
    [SerializeField]
    Button coinTrophyButton, seedlerTrophyButton, dolarsTrophyButton, easterEggTrophyButton;
    [SerializeField]
    GameObject trophyPanel;
    [SerializeField]
    GameObject trophyBar;
    [SerializeField]
    GameObject menuBar;

    private void Start()
    {
        coinTrophyButton.onClick.AddListener(() => ShowTrophy(coinTrophyButton));
        seedlerTrophyButton.onClick.AddListener(() => ShowTrophy(seedlerTrophyButton));
        dolarsTrophyButton.onClick.AddListener(() => ShowTrophy(dolarsTrophyButton));
        easterEggTrophyButton.onClick.AddListener(() => ShowTrophy(easterEggTrophyButton));
    }

    public void ShowHideTrophyBar()
    {
        if (trophyBar != null)
        {
            Animator panelTrophyAnimator = trophyBar.GetComponent<Animator>();
            Animator menuBarAnimator = menuBar.GetComponent<Animator>();
            //Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();

            if (panelTrophyAnimator != null)
            {
                bool isTrophyPanelOpen = panelTrophyAnimator.GetBool("showTrophyBar");
                bool isMenuBarOpen = menuBarAnimator.GetBool("showBar");

                if(!isMenuBarOpen)
                {
                    panelTrophyAnimator.SetBool("showTrophyBar", !isTrophyPanelOpen);
                }
                else if(!isMenuBarOpen && isTrophyPanelOpen)
                {
                    panelTrophyAnimator.SetBool("showTrophyBar", !isTrophyPanelOpen);
                }
                else
                {
                    panelTrophyAnimator.SetBool("showTrophyBar", !isTrophyPanelOpen);
                    menuBarAnimator.SetBool("showBar", !isMenuBarOpen);
                }
            }
        }
    }


    //pass clicked button to show trophy panel
    public void ShowTrophy(Button clickedButton)
    {
        trophyPanel.GetComponent<SlideTrophyPanel>().DefineShowTrophyPanel(clickedButton);
    }

}
