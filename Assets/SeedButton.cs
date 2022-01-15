using Seedling.Managers;
using UnityEngine.UI;
using Seedling.SO;
using UnityEngine;
using TMPro;

public class SeedButton : MonoBehaviour
{
    [SerializeField] private Seed buttonSeed;
    [SerializeField] private Image seedImage;
    [SerializeField] private TMP_Text seedNameText;
    [SerializeField] private TMP_Text seedCuriosText;
    [SerializeField] private TMP_Text seedTimeText;
    [SerializeField] private Button selectButton;
    [SerializeField] private CanvasGroup canvasGroup;

    void Start()
    {
        UpdateButtonUI();   
        selectButton.onClick.AddListener(PickSeedling);  
    }

    private void PickSeedling()
    {
        if(buttonSeed != null)
        {
            GameManager.Instance.seedManager.CurrentSeed = buttonSeed;
            canvasGroup.Disable();
        }
    }

    private void UpdateButtonUI()
    {
        canvasGroup.Enable();
        seedImage.sprite = buttonSeed.seedIcon;
        seedNameText.text = buttonSeed.seedName;
        seedCuriosText.text = buttonSeed.seedCuriosity;
        seedTimeText.text = $"{buttonSeed.growTime}";
    }
}
