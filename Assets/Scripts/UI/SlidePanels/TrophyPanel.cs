using UnityEngine;
using Seedling.SO;

namespace Seedling.UI.Panels
{
    public class TrophyPanel : MonoBehaviour
    {
        [SerializeField] private TrophyInfoPanel trophyInfoPanel;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ShowTrophy(Trophy trophy)
        {
            ShowHidePanel();
            trophyInfoPanel.ShowTrophy(trophy);
        }

        public void ShowHidePanel()
        {
            var isOpen = animator.GetBool("showPanel");
            animator.SetBool("showPanel", !isOpen);
        }
    }
}

