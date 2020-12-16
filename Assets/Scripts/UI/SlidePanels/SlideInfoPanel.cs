using UnityEngine;

public class SlideInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject menuBar;

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
}
