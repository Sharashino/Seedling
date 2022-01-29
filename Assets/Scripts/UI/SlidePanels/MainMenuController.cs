using UnityEngine.UI;
using UnityEngine;

namespace Seedling.UI.Panels
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Sprite menuOpen;
        [SerializeField] private Sprite menuHidden;
        [Header("Panel Animators")]
        [SerializeField] private Animator[] animators; // menu, trophy, seed, info, settings
        [Space, Header("Buttons")]
        [SerializeField] private Button menuButton;
        [SerializeField] private Button trophyButton;
        [SerializeField] private Button seedButton;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;
        private string showPanel = "showPanel";

        private void ShowHideMainMenu(bool state) => animators[0].SetBool(showPanel, state);
        public void SetMenuSprite(Sprite sprite) => menuButton.image.sprite = sprite;

        private void Awake()
        {
            menuButton.onClick.AddListener(() =>
            { 
                OnMenuButtonPress(); 
            });
            trophyButton.onClick.AddListener(() =>
            {
                OnMenuButtonPress(animators[1]); 
            });
            seedButton.onClick.AddListener(() =>
            {
                OnMenuButtonPress(animators[2]); 
            });
            infoButton.onClick.AddListener(() => 
            {
                OnMenuButtonPress(animators[3]); 
            });
            settingsButton.onClick.AddListener(() => 
            {
                OnMenuButtonPress(animators[4]); 
            });
            quitButton.onClick.AddListener(() => 
            {
                QuitGame();
            });
        }

        public void OnMenuButtonPress(Animator animator)
        {
            var isPanelOpen = animator.GetBool(showPanel);
            animator.SetBool(showPanel, !isPanelOpen);

            ShowHideMainMenu(isPanelOpen);
        }

        public void OnMenuButtonPress()
        {
            var isPanelOpen = animators[0].GetBool(showPanel);

            foreach (var anim in animators)
            {
                var isOpen = anim.GetBool(showPanel);

                if (isOpen) anim.SetBool(showPanel, !isOpen);

                if(anim == animators[0]) animators[0].SetBool(showPanel, !isPanelOpen);
            }

            if (!isPanelOpen) SetMenuSprite(menuOpen);
            else SetMenuSprite(menuHidden);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}