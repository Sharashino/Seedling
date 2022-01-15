﻿using TMPro;
using UnityEngine;
using Seedling.UI;

namespace Seedling.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public SeedManager seedManager;


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

        public bool IsBackgroundMuted { get => isBackgroundMuted; set => isBackgroundMuted = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        public int PlayerCoins { get => playerCoins; set => playerCoins = value; }
        public int IrisTimeSpent { get => irisTimeSpent; set => irisTimeSpent = value; }
        public int RoseTimeSpent { get => roseTimeSpent; set => roseTimeSpent = value; }
        public int TulipTimeSpent { get => tulipTimeSpent; set => tulipTimeSpent = value; }
        public int AllTimeSpent { get => allTimeSpent; set => allTimeSpent = value; }

        private void Awake()
        {
            if (Instance != null)
                Instance = this;

            /*//sprawdzenie

            playerName = ES3.Load<string>("playerName");

            if (playerName == "xd")
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
            isBackgroundMuted = ES3.Load("isBackgroundMuted", false);*/
        }

        public void CheckForTrophy()
        {
            if (isIrisUnlocked && isRoseUnlocked && isTulipUnlocked)
            {
                isSeedlerUnlocked = true;
                notificationDisplayer.TrophyUnlocked("Seedler");
            }
        }

        public void UpdateCoins()
        {
            if (playerCoins >= 1000 && !isRichartUnlocked)
            {
                isRichartUnlocked = true;
                notificationDisplayer.TrophyUnlocked("Richart");
            }

            playerCoinsText.text = playerCoins.ToString();
        }

        public void QuitGame()
        {
            Application.Quit();
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
    }
}