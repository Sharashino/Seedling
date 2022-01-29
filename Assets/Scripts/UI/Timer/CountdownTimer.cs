using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Seedling.UI
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text countDownText;
        [SerializeField] private Button addTime;
        [SerializeField] private Button subTime;
        [SerializeField] private Button startTimer;
        [SerializeField] private CanvasGroup[] canvasGroups; // Start, Add, Subtract

        private float timer;
        private int hours;
        private int minutes;
        private int seconds;

        private void Awake()
        {
            addTime.onClick.AddListener(AddTime);    
            subTime.onClick.AddListener(SubtractTime);
            startTimer.onClick.AddListener(() => StartCoroutine(StartCountdown()));

            DisableTimerCanvas(null);
        }

        public void AddTime()
        {
            //Adding to timer in seconds!!!
            timer += 60;
            FormatText();

            if (timer > 0) canvasGroups[0].Enable();
        }

        public void SubtractTime()
        {
            //Subtracting timer in seconds!!!
            if (timer >= 2)
            {
                timer -= 60;
                FormatText();
            }

            if (timer == 0) canvasGroups[0].Disable();
        }

        private IEnumerator StartCountdown()
        {
            DisableTimerCanvas(null);

            while (timer >= 0)
            {
                timer -= Time.deltaTime;
                FormatText();
                yield return null;
            }

            //reset the timer
            timer = 0;
        }

        private void FormatText()
        {
            hours = (int)(timer / 3600) % 24;
            minutes = (int)(timer / 60) % 60;
            seconds = (int)(timer % 60);

            countDownText.text = "";

            #region hours
            if (hours <= 9) countDownText.text += $"0{hours}:";
            else if (hours >= 10) countDownText.text += $"{hours}:";
            else countDownText.text += "00";

            #endregion

            #region minutes
            if (minutes <= 9) countDownText.text += $"0{minutes}:";
            else if (minutes >= 10) countDownText.text += $"{minutes}:";
            else countDownText.text += "00";
            #endregion

            #region seconds
            if (seconds <= 9) countDownText.text += $"0{seconds}";
            else if (seconds >= 10) countDownText.text += seconds;
            else countDownText.text += "00";
            #endregion
        }

        public void DisableTimerCanvas(CanvasGroup canvasToSpare)
        {
            foreach (var cg in canvasGroups)
            {
                if (cg == canvasToSpare) return;

                cg.Disable();
            }
        }
    }
}