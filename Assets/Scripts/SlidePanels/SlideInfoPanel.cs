using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInfoPanel : MonoBehaviour
{
    [SerializeField]
    GameObject infoPanel;
    [SerializeField]
    GameObject menuBar;

    public void ShowHideInfoPanel()
    {
        if (infoPanel != null)
        {
            Animator panelInfoAnimator = infoPanel.GetComponent<Animator>();
            Animator menuBarAnimator = menuBar.GetComponent<Animator>();
            //Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();

            if (panelInfoAnimator != null)
            {
                bool isInfoPanelOpen = panelInfoAnimator.GetBool("showInfoPanel");
                bool isMenuBarOpen = menuBarAnimator.GetBool("showBar");

                panelInfoAnimator.SetBool("showInfoPanel", !isInfoPanelOpen);
                menuBarAnimator.SetBool("showBar", !isMenuBarOpen);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
