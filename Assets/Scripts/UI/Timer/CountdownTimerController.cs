using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

namespace Seedling.UI
{
    public class CountdownTimerController : MonoBehaviour
    {
        [SerializeField] private TMP_Text countDownText;
        [SerializeField] private Button addTimeButton;
        [SerializeField] private Button subtractTimeButton;
        [SerializeField] private Button startTimeButton;
        [SerializeField] private CanvasGroup buttonsCanvasGroup;
        [SerializeField] private CanvasGroup timerCanvasGroup;
        private int timerTick;
        private int hours;
        private int minutes;
        private int seconds;

        public void ShowTimer() => timerCanvasGroup.Enable();

        private void Awake()
        {
            FormatText(0);

            timerCanvasGroup.Disable();

            addTimeButton.onClick.AddListener(delegate { AddTime(60); });
            subtractTimeButton.onClick.AddListener(delegate { SubtractTime(60); });
            startTimeButton.onClick.AddListener(delegate 
            {
                OnStartCountDown();
            });
        }

        private void OnStartCountDown()
        {
            buttonsCanvasGroup.Disable();
            GameTimeManager.OnTimerStart?.Invoke(timerTick);
        }

        public void AddTime(int time)
        {
            timerTick += time;
            FormatText(timerTick);
        }

        public void SubtractTime(int time)
        {
            if (timerTick >= 2)
            {
                timerTick -= time;
                FormatText(timerTick);
            }
        }

        private void FormatText(int time)
        {
            hours = (time / 3600) % 24;
            minutes = (time / 60) % 60;
            seconds = (time % 60);

            countDownText.text = "";

            #region Hours
            if (hours <= 9) countDownText.text += $"0{hours}:";
            else if (hours >= 10) countDownText.text += $"{hours}:";
            else countDownText.text += "00";
            #endregion

            #region Minutes
            if (minutes <= 9) countDownText.text += $"0{minutes}:";
            else if (minutes >= 10) countDownText.text += $"{minutes}:";
            else countDownText.text += "00";
            #endregion

            #region Seconds
            if (seconds <= 9) countDownText.text += $"0{seconds}";
            else if (seconds >= 10) countDownText.text += seconds;
            else countDownText.text += "00";
            #endregion
        }
    }
}