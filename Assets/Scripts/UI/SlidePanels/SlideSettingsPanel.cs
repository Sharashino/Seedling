using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuBar;
    private Animator settingsPanelAnimator;
    private bool showSettingsPanel;

    private void Awake()
    {
        settingsPanelAnimator = settingsPanel.GetComponent<Animator>();
    }

    public void ShowHideSettingsPanel()
    {
        if(settingsPanel != null)
        {
            if (settingsPanelAnimator != null)
            {
                showSettingsPanel = settingsPanelAnimator.GetBool("showSettingsPanel");
                settingsPanelAnimator.SetBool("showSettingsPanel", !showSettingsPanel);
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
