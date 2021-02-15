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
            //Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();

            if (panelInfoAnimator != null)
            {
                bool isInfoPanelOpen = panelInfoAnimator.GetBool("showInfoPanel");

                panelInfoAnimator.SetBool("showInfoPanel", !isInfoPanelOpen);
            }
        }
    }
}
