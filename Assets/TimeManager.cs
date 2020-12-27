using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private SeedlingManager seedlingManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerButtons;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool isCounting;
    
    public bool GetIsCounting()
    {
        return isCounting;
    }
    public bool SetIsCounting(bool state)
    {
        return isCounting = state;
    }

    public void SetTimerText(string text)
    {
        timerText.text = text;
    }

    public void SetTimerButtons(bool isActive)
    {
        timerButtons.SetActive(isActive);
    }

    public void SetSpentTime(int time)
    {
        switch (seedlingManager.GetCurrentSeedling().itemName)
        {
            case "Iris Seeds":
                {
                    gameManager.SetIrisTimeSpent(120);

                    if (gameManager.GetIrisTimeSpent() >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                    {
                        seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                    }
                }
                break;
            case "Rose Seeds":
                {
                    gameManager.SetRoseTimeSpent(time);

                    if (gameManager.GetRoseTimeSpent() >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                    {
                        seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                    }
                }
                break;
            case "Tulip Seeds":
                {
                    gameManager.SetTulipTimeSpent(time);

                    if (gameManager.GetTulipTimeSpent() >= seedlingManager.GetCurrentSeedling().minutesToGrow)
                    {
                        seedlingManager.GrowFlower(seedlingManager.GetCurrentSeedling());
                    }
                }
                break;
            default:
                break;
        }
    }
}

