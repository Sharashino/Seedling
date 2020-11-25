using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using TMPro;
public class SlideTrophyPanel : MonoBehaviour
{
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
        trophyImage.sprite = clickedButton.GetComponent<Image>().sprite;
        trophyName.text = clickedButton.GetComponent<DefineTrophy>().trophyName;
        trophyDesc.text = clickedButton.GetComponent<DefineTrophy>().trophyDesc;
    }
}