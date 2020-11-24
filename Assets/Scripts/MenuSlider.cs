using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
    [SerializeField]
    GameObject panelMenu;
    [SerializeField]
    GameObject seedlingSelector;
  
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

                panelMenuAnimator.SetBool("showBar", !isOpen);

            }
        } 
    }
}
