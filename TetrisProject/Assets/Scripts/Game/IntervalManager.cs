using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntervalManager : MonoBehaviour
{
    /// <summary>
    /// Time interval in seconds.
    /// </summary>

    private const float FRAME_PERIOD = 1 / Global.FrameRate;
    private static int numIntervals = 0;
    private static float lastRunTime = 0f;
    private Dictionary<int, UnityEvent> intervalDictionary;
    private static IntervalManager intervalManager;

    public static IntervalManager instance
    {
        get
        {
            if (!intervalManager)
            {
                intervalManager = FindObjectOfType(typeof(IntervalManager)) as IntervalManager;
                if (!intervalManager)
                    Debug.LogError("Need the IntervalManager script on an object in the scene.");
                else
                    intervalManager.ManualInit();
            }
            return intervalManager;
        }
    }

    void ManualInit()
    {
        if (intervalDictionary == null)
            intervalDictionary = new Dictionary<int, UnityEvent>();
    }

    public static void StartListening(int interval, UnityAction listener)
    {
        if (interval <= 0)
            return;

        UnityEvent thisEvent = null;

        if (instance.intervalDictionary.TryGetValue(interval, out thisEvent))
            thisEvent.AddListener(listener);
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.intervalDictionary.Add(interval, thisEvent);
        }
    }

    public static void StopListening(int interval, UnityAction listener)
    {
        if (instance.intervalDictionary == null)
            return;

        UnityEvent thisEvent = null;

        if (instance.intervalDictionary.TryGetValue(interval, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    void Update()
    {
        if (instance.intervalDictionary == null)
            return;

        while (Time.time - lastRunTime >= FRAME_PERIOD)
        {
            numIntervals++;
            lastRunTime += FRAME_PERIOD;

            foreach (var i in instance.intervalDictionary.Keys)
                if (numIntervals % i == 0)
                {
                    UnityEvent thisEvent = null;

                    if (instance.intervalDictionary.TryGetValue(i, out thisEvent))
                        thisEvent.Invoke();
                }
        }
    }
}