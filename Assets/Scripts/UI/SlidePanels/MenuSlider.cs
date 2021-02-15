using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    [SerializeField] private Sprite hideSprite;
    [SerializeField] private Sprite showSprite;
    [SerializeField] private Button showHideMenuBar;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject trophyBar;
    [SerializeField] private GameObject trophyPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject seedlingSelector;
    [SerializeField] private GameObject timer;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private NotificationDisplayer notificationDisplayer;

    private Animator menuBarAnimator;
    private Animator seedlingSelectorAnimator;
    private Animator trophyBarAnimator;
    private Animator trophyPanelAnimator;
    private Animator settingsPanelAnimator;

    private bool isOpen = true;
    private bool isSelectorOpen;
    private bool isTrophyBarOpen;
    private bool isTrophyPanelOpen;
    private bool isSettingsPanelOpen;

    private void Awake()
    {
        menuBarAnimator = panelMenu.GetComponent<Animator>();
        seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();
        trophyBarAnimator = trophyBar.GetComponent<Animator>();
        trophyPanelAnimator = trophyPanel.GetComponent<Animator>();
        settingsPanelAnimator = settingsPanel.GetComponent<Animator>();
    }

    private void Update()
    {
        //ChangeMenuSprite();
    }

    private void ChangeMenuSprite()
    {
        if (!isOpen)
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
            if (menuBarAnimator != null)
            {
                isOpen = menuBarAnimator.GetBool("showBar");

                ChangeMenuSprite();

                isSelectorOpen = seedlingSelectorAnimator.GetBool("showSelector");
                isTrophyBarOpen = trophyBarAnimator.GetBool("showTrophyBar");
                isTrophyPanelOpen = trophyPanelAnimator.GetBool("showTrophyPanel");
                isSettingsPanelOpen = settingsPanelAnimator.GetBool("showSettingsPanel");

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
                else if(isSettingsPanelOpen)
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                    settingsPanelAnimator.SetBool("showSettingsPanel", !isSettingsPanelOpen);   
                }
                else if(!isTrophyBarOpen && !isTrophyPanelOpen && !isSelectorOpen && !timeManager.IsCounting)
                {
                    menuBarAnimator.SetBool("showBar", !isOpen);
                }
                else if(timeManager.IsCounting)
                {
                    notificationDisplayer.WaitTillTimerDone();
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
