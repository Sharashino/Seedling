using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
    [SerializeField]
    GameObject panelMenu;
    [SerializeField]
    GameObject seedlingSelector;
    [SerializeField]
    GameObject timer;
    public void ShowHideMenu()
    {
        if (panelMenu != null)
        {
            Animator panelMenuAnimator = panelMenu.GetComponent<Animator>();
            Animator seedlingSelectorAnimator = seedlingSelector.GetComponent<Animator>();

            if (panelMenuAnimator != null)
            {
                bool isOpen = panelMenuAnimator.GetBool("showBar");
                bool isSelectorOpen = seedlingSelectorAnimator.GetBool("showSelector");


                //if SeedlingSelector is open hide it and open MenuBar
                //if it isnt just open MenuBar and hide timer
                if(isSelectorOpen)
                {
                    panelMenuAnimator.SetBool("showBar", !isOpen);
                    seedlingSelectorAnimator.SetBool("showSelector", !isSelectorOpen);
                }
                else
                {
                    panelMenuAnimator.SetBool("showBar", !isOpen);
                }


            }
        } 
    }
}
