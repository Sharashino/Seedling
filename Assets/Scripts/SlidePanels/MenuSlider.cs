using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    [SerializeField]
    Sprite hideSprite;
    [SerializeField]
    Sprite showSprite;
    [SerializeField]
    Button showHideMenuBar;

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

    Animator menuBarAnimator;
    Animator seedlingSelectorAnimator;
    Animator trophyBarAnimator;
    Animator trophyPanelAnimator;

    public bool isOpen = true;
    bool isSelectorOpen;
    bool isTrophyBarOpen;
    bool isTrophyPanelOpen;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(!isOpen)
        {
            showHideMenuBar.image.sprite = showSprite;
        }
        else
        {
            showHideMenuBar.image.sprite = hideSprite;
        }
    }

    public void ShowHideMenu()
    {
        if (panelMenu != null)
        {
            menuBarAnimator = panelMenu.GetComponent<Animator>();
            seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();
            trophyBarAnimator = trophyBar.GetComponent<Animator>();
            trophyPanelAnimator = trophyPanel.GetComponent<Animator>();

            if (menuBarAnimator != null)
            {
                isOpen = menuBarAnimator.GetBool("showBar");
                isSelectorOpen = seedlingSelectorAnimator.GetBool("showSelector");
                isTrophyBarOpen = trophyBarAnimator.GetBool("showTrophyBar");
                isTrophyPanelOpen = trophyPanelAnimator.GetBool("showTrophyPanel");

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
