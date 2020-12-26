using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] SeedlingManager seedlingManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timerButtons;
    [SerializeField] TMP_Text timerText;

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

