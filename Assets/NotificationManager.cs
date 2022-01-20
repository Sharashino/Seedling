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
        public float NotificationFadeTime { get => notificationFadeTime; set => notificationFadeTime = value; }

        // Start is called before the first frame update
        void Awake()
        {
            if (!_instance)
            {
                _instance = this;
            }
        }

    }
}