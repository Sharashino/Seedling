using Seedling.UI.Panels;
using Seedling.Managers;
using UnityEngine.UI;
using Seedling.SO;
using UnityEngine;
using TMPro;

namespace Seedling.UI.Buttons
{
    public class SeedButton : MonoBehaviour
    {
        [SerializeField] private SeedSO seed;
        [SerializeField] private Image seedImage;
        [SerializeField] private TMP_Text seedNameText;
        [SerializeField] private TMP_Text seedCuriosText;
        [SerializeField] private TMP_Text seedTimeText;
        private SeedPanel seedPanel;
        private Button seedButton;

        void Awake()
        {
            InitButton();

            seedButton.onClick.AddListener(PickSeedling);
        }

        private void PickSeedling()
        {
            if (seed != null)
            {
                SeedManager.Instance.CurrentSeed = seed;
                NotificationManager.Instance.DisplayNotification($"You have picked {seed.seedName}");
                seedPanel.ShowHidePanel();
            }
        }

        private void InitButton()
        {
            seedPanel = GetComponentInParent<SeedPanel>();
            seedButton = GetComponent<Button>();

            seedImage.sprite = seed.seedIcon;
            seedNameText.text = seed.seedName;
            seedCuriosText.text = seed.seedCuriosity;
            seedTimeText.text = $"{seed.growTime}";
        }
    }
}

