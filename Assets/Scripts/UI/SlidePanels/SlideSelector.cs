using UnityEngine;

public class SlideSelector : MonoBehaviour
{
    [SerializeField] private GameObject seedlingSelector;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject timer;
    
    public void ShowHideSelector()
    {
        if (panelMenu != null)
        {
            Animator panelMenuAnimator = panelMenu.GetComponent<Animator>();
            Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();

            if (panelMenuAnimator != null)
            {
                bool isBarOpen = panelMenuAnimator.GetBool("showBar");
                bool isSelectorOpen = seedlingSelectorAnimator.GetBool("showSelector");
                bool isTimerOpen = timer.gameObject.activeSelf;

                //if MenuBar is open hide MenuBar and show SeedlingSelector
                //if isnt just show MenuBar
                if(isBarOpen)
                {
                    seedlingSelectorAnimator.SetBool("showSelector", !isSelectorOpen);
                    panelMenuAnimator.SetBool("showBar", !isBarOpen);
                    timer.SetActive(false);
                }
                else
                {
                    //also update the seedling selector times
                    seedlingSelectorAnimator.SetBool("showSelector", !isSelectorOpen);
                }
            }
        }
    }
}
