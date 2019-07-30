using UnityEngine;

public class Global : MonoBehaviour
{
    public const int FrameRate = 60;
    public const int DelayedAutoShiftInitialFrameDelay = 16;
    public const int DelayedAutoShiftMainFrameDelay = 6;
    public const int SlideSpeed = 1;
    public readonly int[] linesToTransition = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 100, 100, 100, 100, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300 };
    public readonly int[] levelSpeeds = { 48, 43, 38, 33, 28, 23, 18, 13, 8, 6, 5, 5, 5, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1 };
    public readonly int[] pointTotals = { 40, 100, 300, 1200 };

    public static int score = 0;
    public static int lines = 0;
    public static int level = 0;
    public static int burn = 0;
    public static int drought = 0;
    public static string message = string.Empty;
    public int messageDuration = 180;

    private int originalMessageDuration;

    public static bool IsInBounds(Vector3 block)
    {
        var leftBound = block.x >= -0.001f;
        var rightBound = block.x <= 9.001f;
        var lowerBound = block.y >= -0.001f;
        return leftBound && rightBound && lowerBound;
    }

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FrameRate;
        originalMessageDuration = messageDuration;
    }

    void Update()
    {
        if (messageDuration > 0 && message != string.Empty)
            messageDuration--;
        else
        {
            message = string.Empty;
            messageDuration = originalMessageDuration;
        }
    }
}
