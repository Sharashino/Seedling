using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSettingsPanel : MonoBehaviour
{
    [SerializeField]
    GameObject settingsPanel;
    [SerializeField]
    GameObject menuBar;
    
    bool showSettingsPanel;
    bool showMenuBar;
    public void ShowHideSettingsPanel()
    {
        if(settingsPanel != null)
        {
            Animator settingsPanelAnimator = settingsPanel.GetComponent<Animator>();
            Animator menuBarAnimator = menuBar.GetComponent<Animator>();
            
            
            if (settingsPanelAnimator != null)
            {
                showSettingsPanel = settingsPanelAnimator.GetBool("showSettingsPanel");
                showMenuBar = menuBarAnimator.GetBool("showBar");

                settingsPanelAnimator.SetBool("showSettingsPanel", !showSettingsPanel);
                menuBarAnimator.SetBool("showBar", !showMenuBar);
            }
        }
    }
}
