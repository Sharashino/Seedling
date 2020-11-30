using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject seedlingSelector;
    
    [SerializeField]
    GameObject timer;

    public void OnMenuPress()
    {
        if(seedlingSelector.activeSelf && gameManager.plantedSeed != null)
        {
            //when player clicks on menu button disable seedling selector
            //enable timer
            //resumue timer if player set a timer
            seedlingSelector.SetActive(false);
            timer.SetActive(true);
            timer.GetComponent<CountdownTimer>().StartTimer();
        }
        else if(seedlingSelector.activeSelf && gameManager.plantedSeed == null)
        {
            //when player has no seedling planted disable selector
            //also disable timer
            seedlingSelector.SetActive(false);
            timer.SetActive(false);
        }
        else
        {
            //stop timer when player enables seedling selector
            //disable timer
            seedlingSelector.SetActive(true);
            seedlingSelector.GetComponentInChildren<DefineSeedling>().UpdatePanel();
            timer.SetActive(false);
        }
    }

}
