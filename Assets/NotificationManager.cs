using Seedling.UI;
using UnityEngine;

namespace Seedling.Managers
{
    public class NotificationManager : MonoBehaviour
    {
        #region Singleton

        private static NotificationManager _instance = null;
        public static NotificationManager Instance
        {
            get
            {
                if (_instance == null) Debug.LogError("[GameManager-Static] No Game Manager on the scene!");
                return _instance;
            }
            private set => _instance = value;
        }


        #endregion

        [SerializeField] private float notificationFadeTime;
        [SerializeField] private NotificationDisplayer notificationDisplayer;

        public float NotificationFadeTime { get => notificationFadeTime; set => notificationFadeTime = value; }
        public NotificationDisplayer NotificationDisplayer { get => notificationDisplayer; set => notificationDisplayer = value; }

        // Start is called before the first frame update
        void Awake()
        {
            if (!_instance)
            {
                _instance = this;
            }
        }

        public void DisplayNotification(string text)
        {
            notificationDisplayer.DisplayNotification(text, notificationFadeTime);
        }
    }
}