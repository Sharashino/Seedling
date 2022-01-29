using UnityEngine;
using System;
using Seedling.UI;

public class TimeManager : MonoBehaviour
{
    #region Singleton

    private static TimeManager _instance = null;
    public static TimeManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("[GameTimeManager - Static] No GameTimeManager on the scene!");
            return _instance;
        }
        private set => _instance = value;
    }

    #endregion

    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }
    
    [SerializeField] private CountdownTimer countdownTimer;

    public static event Action<OnTickEventArgs> OnTick_10;   // 10 Ticks in 1 second
    public static event Action<OnTickEventArgs> OnTick_1; // 1 Tick in 1 second

    private const float TICK_TIMER_MAX = 0.1f;  // 
    private int tick;
    private float tickTimer;
    private void Awake()
    {
        if (_instance != null) _instance = this;

        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;

        if (tickTimer >= TICK_TIMER_MAX)
        {
            tickTimer -= TICK_TIMER_MAX;
            tick++;

            if (OnTick_10 != null)
            {
                OnTick_10(new OnTickEventArgs
                {
                    tick = tick
                });
            }

            if (tick % 10 == 0)
            {
                if (OnTick_1 != null)
                {
                    OnTick_1(new OnTickEventArgs
                    {
                        tick = tick
                    });
                }
            }
        }
    }

    public void ShowTimerButtons()
    {

    }
}
