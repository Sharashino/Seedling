using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedlingSelector : MonoBehaviour
{
    [SerializeField]
    GameObject seedlingSelector;
    public void EnableDisableSelector()
    {
        if(seedlingSelector.activeSelf)
        {
            seedlingSelector.SetActive(false);
        }
        else
        {
            seedlingSelector.SetActive(true);
        }
    }
}
