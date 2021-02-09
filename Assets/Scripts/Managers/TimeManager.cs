﻿using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private SeedlingManager seedlingManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject timerButtons;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool isCounting;

    private void Update()
    {
        if(isCounting)
        {
            timerButtons.SetActive(false);
        }
        else
        {
            timerButtons.SetActive(true);
        }
    }

    public bool IsCounting
    {
        get
        {
            return isCounting;
        }
        set
        {
            isCounting = value;
        }
    }

    public bool TimerButtons
    {
        get
        {
            return timerButtons;
        }
        set
        {
            timerButtons.SetActive(value);
        }
    }

    public void SetSpentTime(int time)
    {
        switch (seedlingManager.CurrentSeedling.itemName)
        {
            case "Iris Seeds":
                {
                    gameManager.IrisTimeSpent = time;

                    if (gameManager.IrisTimeSpent >= seedlingManager.CurrentSeedling.minutesToGrow)
                    {
                        seedlingManager.GrowFlower(seedlingManager.CurrentSeedling);
                    }
                }
                break;
            case "Rose Seeds":
                {
                    gameManager.RoseTimeSpent = time;

                    if (gameManager.RoseTimeSpent >= seedlingManager.CurrentSeedling.minutesToGrow)
                    {
                        seedlingManager.GrowFlower(seedlingManager.CurrentSeedling);
                    }
                }
                break;
            case "Tulip Seeds":
                {
                    gameManager.TulipTimeSpent = time;

                    if (gameManager.TulipTimeSpent >= seedlingManager.CurrentSeedling.minutesToGrow)
                    {
                        seedlingManager.GrowFlower(seedlingManager.CurrentSeedling);
                    }
                }
                break;
            default:
                break;
        }
    }
}

