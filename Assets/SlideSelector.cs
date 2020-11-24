using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSelector : MonoBehaviour
{
    [SerializeField]
    GameObject seedlingSelector;
    [SerializeField]
    GameObject panelMenu;
    private void Start()
    {
        //panelMenu.SetActive(false);
    }

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

                if(isBarOpen)
                {
                    seedlingSelectorAnimator.SetBool("showSelector", !isSelectorOpen);
                    panelMenuAnimator.SetBool("showBar", !isBarOpen);
                }
                else
                {
                    seedlingSelectorAnimator.SetBool("showSelector", !isSelectorOpen);
                }
            }
        }
    }
}
