using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
    [SerializeField]
    GameObject panelMenu;

    private void Start()
    {
        //panelMenu.SetActive(false);
    }

    public void ShowHideMenu()
    {
        if(panelMenu != null)
        {
            Animator animator = panelMenu.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("showPanel");
                animator.SetBool("showPanel", !isOpen);
            }
        }
    }
}
