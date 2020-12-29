using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerCoinsText;
    [SerializeField] private NotificationDisplayer notificationDisplayer;
    [SerializeField] private GameObject seedlingSelector;

    [Header("Player basic info")]
    [SerializeField] private string playerName;
    [SerializeField] private int playerCoins;

    [Header("Player time spent on plants")]
    [SerializeField] private int allTimeSpent;
    [SerializeField] private int irisTimeSpent;
    [SerializeField] private int roseTimeSpent;
    [SerializeField] private int tulipTimeSpent;

    [Header("Player seeds unlocked")]
    public bool isIrisUnlocked;
    public bool isRoseUnlocked;
    public bool isTulipUnlocked;

    [Header("Player Trophies")]
    public bool isRichartUnlocked;
    public bool isSeedlerUnlocked;
    public bool isSupporterUnlocked;
    public bool isIndianaJohnesUnlocked;

    [Header("Sounds")]
    [SerializeField] private bool isBackgroundMuted;

    private void Awake()
    {
        playerName = ES3.Load<string>("playerName");

        if(playerName == "xd")
        {
            isIndianaJohnesUnlocked = true;
        }

        playerCoins = ES3.Load("playerCoins", 0);

        irisTimeSpent = ES3.Load("irisTimeSpent", 0);
        roseTimeSpent = ES3.Load("roseTimeSpent", 0);
        tulipTimeSpent = ES3.Load("tulipTimeSpent", 0);
        allTimeSpent = ES3.Load("allTimeSpent", 0);

        isIrisUnlocked = ES3.Load("isIrisUnlocked", false);
        isRoseUnlocked = ES3.Load("isRoseUnlocked", false);
        isTulipUnlocked = ES3.Load("isTulipUnlocked", false);

        isRichartUnlocked = ES3.Load("isRichartUnlocked", false);
        isSeedlerUnlocked = ES3.Load("isSeedlerUnlocked", false);
        isSupporterUnlocked = ES3.Load("isSupporterUnlocked", false);
        isIndianaJohnesUnlocked = ES3.Load("isIndianaJohnesUnlocked", false);

        isBackgroundMuted = ES3.Load("isAllMuted", false);
        isBackgroundMuted = ES3.Load("isBackgroundMuted", false);

        playerCoinsText.text = playerCoins.ToString();
    }

    public void CheckForTrophy()
    {
        if(isIrisUnlocked && isRoseUnlocked && isTulipUnlocked)
        {
            isSeedlerUnlocked = true;
            notificationDisplayer.TrophyUnlocked("Seedler");
        }
    }

    public void UpdateCoins()
    {
        if(playerCoins >= 1000 && !isRichartUnlocked)
        {
            isRichartUnlocked = true;
            notificationDisplayer.TrophyUnlocked("Richart");
        }

        playerCoinsText.text = playerCoins.ToString();
    }

    private void OnApplicationQuit()
    {
        ES3.Save("playerName", playerName);
        ES3.Save("playerCoins", playerCoins);

        ES3.Save("allTimeSpent", allTimeSpent);

        ES3.Save("irisTimeSpent", irisTimeSpent);
        ES3.Save("roseTimeSpent", roseTimeSpent);
        ES3.Save("tulipTimeSpent", tulipTimeSpent);

        ES3.Save("isIrisUnlocked", isIrisUnlocked);
        ES3.Save("isRoseUnlocked", isRoseUnlocked);
        ES3.Save("isTulipUnlocked", isTulipUnlocked);

        ES3.Save("isRichartUnlocked", isRichartUnlocked);
        ES3.Save("isSeedlerUnlocked", isSeedlerUnlocked);
        ES3.Save("isSupporterUnlocked", isSupporterUnlocked);
        ES3.Save("isIndianaJohnesUnlocked", isIndianaJohnesUnlocked);

        ES3.Save("isAllMuted", isBackgroundMuted);
        ES3.Save("isBackgroundMuted", isBackgroundMuted);
    }

    public string GetPlayerName()
    {
        return playerName;
    }
    public int GetPlayerCoins()
    {
        return playerCoins;
    }
    public int GetIrisTimeSpent()
    {
        return irisTimeSpent;
    }
    public int GetRoseTimeSpent()
    {
        return roseTimeSpent;
    }
    public int GetTulipTimeSpent()
    {
        return tulipTimeSpent;
    }
    public int GetAllTimeSpent()
    {
        return allTimeSpent;
    }
    public string SetPlayerName(string name)
    {
        return playerName = name;
    }
    public int SetPlayerCoins(int coins)
    {
        return playerCoins += coins;
    }
    public int SetIrisTimeSpent(int time)
    {
        if(time == 0)
        {
            return irisTimeSpent = 0;
        }
        else
        {
            return irisTimeSpent += time;
        }
    }
    public int SetRoseTimeSpent(int time)
    {
        if (time == 0)
        {
            return roseTimeSpent = 0;
        }
        else
        {
            return roseTimeSpent += time;
        }
    }
    public int SetTulipTimeSpent(int time)
    {
        if (time == 0)
        {
            return tulipTimeSpent = 0;
        }
        else
        {
            return tulipTimeSpent += time;
        }
    }
    public int SetAllTimeSpent(int time)
    {
        if (time == 0)
        {
            return allTimeSpent = 0;
        }
        else
        {
            return allTimeSpent += time;
        }
    }

    public bool GetIsAllMuted()
    {
        return isBackgroundMuted;
    }

    public bool GetIsBackgroundMuted()
    {
        return isBackgroundMuted;
    }

    public bool SetIsBackgroundMuted(bool state)
    {
        return isBackgroundMuted = state;
    }
}
