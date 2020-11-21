using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    GameObject seedlingSelector;
    
    [SerializeField]
    GameObject timer;
    public void OnMenuPress()
    {
        if(seedlingSelector.activeSelf)
        {
            //when player clicks on menu button disable seedling selector
            //enable timer
            //resumue timer if player set a timer
            seedlingSelector.SetActive(false);
            timer.SetActive(true);
            timer.GetComponent<CountdownTimer>().StartTimer();
        }
        else
        {
            //stop timer when player enables seedling selector
            //disable timer
            seedlingSelector.SetActive(true);
            timer.SetActive(false);
        }
    }
}
