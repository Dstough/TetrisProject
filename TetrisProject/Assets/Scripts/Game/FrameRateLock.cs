using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLock : MonoBehaviour
{
    public int FrameRate;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FrameRate;
    }

    void Update()
    {
    }
}
