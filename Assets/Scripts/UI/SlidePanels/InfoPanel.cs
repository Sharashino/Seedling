using UnityEngine.UI;
using UnityEngine;

namespace Seedling.UI.Panels
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Button infoButton;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            infoButton.onClick.AddListener(ShowHideInfo);
        }

        public void ShowHideInfo()
        {
            bool isOpen = animator.GetBool("showPanel");
            animator.SetBool("showPanel", !isOpen);
        }
    }
}
