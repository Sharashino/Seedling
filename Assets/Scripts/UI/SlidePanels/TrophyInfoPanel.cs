using UnityEngine.UI;
using UnityEngine;
using Seedling.SO;
using TMPro;

namespace Seedling.UI.Panels
{
    public class TrophyInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text trophyName;
        [SerializeField] private TMP_Text trophyDesc;
        [SerializeField] private Image trophyImage;
        [SerializeField] private Button trophyInfoButton;
        [SerializeField] private TrophyPanel trophyPanel;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            trophyInfoButton.onClick.AddListener(() => ShowHidePanel());
        }

        public void ShowHidePanel()
        {
            var isOpen = animator.GetBool("showPanel");
            animator.SetBool("showPanel", !isOpen);

            if (isOpen) trophyPanel.ShowHidePanel();
        }

        public void ShowTrophy(Trophy trophy)
        {
            ShowHidePanel();

            trophyName.text = trophy.trophyName;
            trophyDesc.text = trophy.trophyDesc;
            trophyImage.sprite = trophy.trophyImage;
        }
    }
}