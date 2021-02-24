using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Seedling.Managers;

public class SlideTrophyBar : MonoBehaviour
{

    [SerializeField] private NotificationDisplayer notificationDisplayer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button coinTrophyButton, seedlerTrophyButton, dolarsTrophyButton, easterEggTrophyButton;
    [SerializeField] private GameObject trophyPanel;
    [SerializeField] private GameObject trophyBar;
    [SerializeField] private GameObject menuBar;
    
    private void Start()
    {
        coinTrophyButton.onClick.AddListener(() => ShowTrophy(coinTrophyButton));
        seedlerTrophyButton.onClick.AddListener(() => ShowTrophy(seedlerTrophyButton));
        dolarsTrophyButton.onClick.AddListener(() => ShowTrophy(dolarsTrophyButton));
        easterEggTrophyButton.onClick.AddListener(() => ShowTrophy(easterEggTrophyButton));
    }

    //checking if you unlocked trophies and displaying notification
    private void UpdateTrophyPanel()
    {
        if(gameManager.isRichartUnlocked)
        {
            coinTrophyButton.GetComponent<Image>().color = Color.white;
            coinTrophyButton.GetComponentInChildren<TMP_Text>().text = coinTrophyButton.GetComponent<DefineTrophy>().TrophyObject.trophyName;
        }
        else if(gameManager.isSeedlerUnlocked)
        {
            seedlerTrophyButton.GetComponent<Image>().color = Color.white;
            seedlerTrophyButton.GetComponentInChildren<TMP_Text>().text = seedlerTrophyButton.GetComponent<DefineTrophy>().TrophyObject.trophyName;
        }
        else if(gameManager.isSupporterUnlocked)
        {
            dolarsTrophyButton.GetComponent<Image>().color = Color.white;
            dolarsTrophyButton.GetComponentInChildren<TMP_Text>().text = dolarsTrophyButton.GetComponent<DefineTrophy>().TrophyObject.trophyName;
        }
        else if(gameManager.isIndianaJohnesUnlocked)
        {
            easterEggTrophyButton.GetComponent<Image>().color = Color.white;
            easterEggTrophyButton.GetComponentInChildren<TMP_Text>().text = easterEggTrophyButton.GetComponent<DefineTrophy>().TrophyObject.trophyName;
        }
        else
        {
            Debug.Log("no changes in trophies :(");
        }
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

                UpdateTrophyPanel();

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
    private void ShowTrophy(Button clickedButton)
    {
        trophyPanel.GetComponent<SlideTrophyPanel>().GetClickedTrophy(clickedButton);
    }
}
