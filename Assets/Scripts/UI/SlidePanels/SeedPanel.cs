using UnityEngine;

namespace Seedling.UI.Panels
{
    public class SeedPanel : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ShowHidePanel()
        {
            var isOpen = animator.GetBool("showPanel");
            animator.SetBool("showPanel", !isOpen);
        }
    }
}

