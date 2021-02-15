using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideTrophyPanel : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject trophyPanel;
    [SerializeField] private Image trophyImage;
    [SerializeField] private TMP_Text trophyName;
    [SerializeField] private TMP_Text trophyDesc;

    public void ShowHideTrophyPanel()
    {
        if (trophyPanel != null)
        {
            Animator panelTrophyAnimator = trophyPanel.GetComponent<Animator>();

            if (panelTrophyAnimator != null)
            {
                bool isTrophyPanelOpen = panelTrophyAnimator.GetBool("showTrophyPanel");
                panelTrophyAnimator.SetBool("showTrophyPanel", !isTrophyPanelOpen);
            }
        }
    }

    private void DefineShowTrophyPanel(Button clickedButton) 
    {
        var Trophy = clickedButton.GetComponent<DefineTrophy>();
        trophyImage.sprite = clickedButton.GetComponent<Image>().sprite;
        trophyDesc.text = Trophy.trophyDesc;

        //here we re switching trophy name to show ??? when Trophy locked and its name when unlocked
        switch (Trophy.trophyType)
        {
            case TrophyType.Richart:
                if(gameManager.isRichartUnlocked)
                    trophyName.text = Trophy.trophyName;
                else
                    trophyName.text = "???";
                break;
            case TrophyType.Seedler:
                if (gameManager.isSeedlerUnlocked)
                    trophyName.text = Trophy.trophyName;
                else
                    trophyName.text = "???";
                break;
            case TrophyType.Supporter:
                if (gameManager.isSupporterUnlocked)
                    trophyName.text = Trophy.trophyName;
                else
                    trophyName.text = "???";
                break;
            case TrophyType.IndianaJohnes:
                if (gameManager.isIndianaJohnesUnlocked)
                    trophyName.text = Trophy.trophyName;
                else
                    trophyName.text = "???";
                break;
            default:
                break;
        }
    }

    public void GetClickedTrophy(Button clickedButton)
    {
        DefineShowTrophyPanel(clickedButton);
    }
}