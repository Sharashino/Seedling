using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
    [SerializeField]
    GameObject panelMenu;
    [SerializeField]
    GameObject trophyBar;
    [SerializeField]
    GameObject trophyPanel;
    [SerializeField]
    GameObject seedlingSelector;
    [SerializeField]
    GameObject timer;
    public void ShowHideMenu()
    {
        if (panelMenu != null)
        {
            Animator menuBarAnimator = panelMenu.GetComponent<Animator>();
            Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();
            Animator trophyBarAnimator = trophyBar.GetComponent<Animator>();
            Animator trophyPanelAnimator = trophyPanel.GetComponent<Animator>();

            if (menuBarAnimator != null)
            {
                bool isOpen = menuBarAnimator.GetBool("showBar");
                bool isSelectorOpen = seedlingSelectorAnimator.GetBool("showSelector");
                bool isTrophyBarOpen = trophyBarAnimator.GetBool("showTrophyBar");
                bool isTrophyPanelOpen = trophyPanelAnimator.GetBool("showTrophyPanel");

                //if SeedlingSelector is open hide it and open MenuBar
                if(isSelectorOpen)
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                    seedlingSelectorAnimator.SetBool("showSelector", !isSelectorOpen);
                }
                //if TrophyBar is open hide it and open MenuBar
                else if(isTrophyBarOpen)
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                    trophyBarAnimator.SetBool("showTrophyBar", !isTrophyBarOpen);
                }
                //if TrophyPanel is open hide it and open MenuBar
                else if(isTrophyPanelOpen)
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                    trophyPanelAnimator.SetBool("showTrophyPanel", !isTrophyPanelOpen);
                }
                else if(!isTrophyBarOpen && !isTrophyPanelOpen && !isSelectorOpen)
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                }
                //if it isnt just open MenuBar
                else
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                }


            }
        } 
    }
}
