using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuBar;
    private bool showSettingsPanel;
    private bool showMenuBar;

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

    public void OnDonateButton()
    {
        Application.OpenURL("https://www.paypal.com/donate?hosted_button_id=7SGWW4Q262BBS");
    }

    public void OnResetDataButton()
    {
        ES3.DeleteFile("SaveFile.es3");
        Application.Quit();
    }

    public void OnMuteAudioButton()
    {
        //MUTE ALL AUDIO AND SAVE IT
    }
}
