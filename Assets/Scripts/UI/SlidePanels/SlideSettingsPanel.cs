using UnityEngine.UI;
using UnityEngine;

namespace Seedling.UI.Panels
{
    public class SlideSettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button resetDataButton;
        [SerializeField] private Button donateButton;
        [SerializeField] private Toggle muteToggle;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            settingsButton.onClick.AddListener(ShowHideSettings);
            resetDataButton.onClick.AddListener(OnResetData);
            donateButton.onClick.AddListener(OnDonate);
        }

        public void ShowHideSettings()
        {
            bool isOpen = animator.GetBool("showPanel");
            animator.SetBool("showPanel", !isOpen);
        }

        public void OnDonate() => Application.OpenURL("https://www.paypal.com/donate?hosted_button_id=7SGWW4Q262BBS");

        public void OnResetData()
        {
            Application.Quit();
        }

        public void OnMuteAudioButton()
        {
            //MUTE ALL AUDIO AND SAVE IT
        }
    }
}

