using Seedling.UI.Panels;
using UnityEngine.UI;
using UnityEngine;
using Seedling.SO;

namespace  Seedling.UI.Buttons
{
    public class TrophyButton : MonoBehaviour
    {
        [SerializeField] private Trophy trophy;
        private TrophyPanel trophyPanel;
        private Button button;

        private void Awake()
        {
            trophyPanel = GetComponentInParent<TrophyPanel>();
            button = GetComponent<Button>();
            button.onClick.AddListener(() => ShowTrophy());
        }

        private void ShowTrophy()
        {
            trophyPanel.ShowTrophy(trophy);
        }
    }
}