using UnityEngine;
using System;

public class GameTimeManager : MonoBehaviour
{
    #region Singleton

    private static GameTimeManager _instance = null;
    public static GameTimeManager Instance
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
        public int time;
    }

    public static event Action<OnTickEventArgs> OnTick_1; // 1 Tick in 1 second
    public static Action<int> OnTimerStart;
    public static Action OnTimerEnd;

    private const float TICK_TIMER_MAX = 0.1f;  // 
    private int tick;
    private float timerTick;
    private int ticksLeft;

    private void Awake()
    {
        if (_instance != null) _instance = this;

        tick = 0;

        OnTimerStart += OnStartPress;
    }

    private void Update()
    {
        RunTimer();
    }

    private void RunTimer()
    {
        timerTick += Time.deltaTime;

        if (timerTick >= TICK_TIMER_MAX)
        {
            timerTick -= TICK_TIMER_MAX;
            tick++;

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

    private void OnStartPress(int time)
    {
        ticksLeft = time;
        OnTick_1 += StartTime;
    }

    private void StartTime(OnTickEventArgs obj)
    {
        ticksLeft--;

        if(ticksLeft == 0)
        {
            OnTimerEnd?.Invoke();
        }
    }
}
