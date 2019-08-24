using UnityEngine;
using System.Collections.Generic;

public class Global : MonoBehaviour
{
    public const int FrameRate = 60;
    public const int DelayedAutoShiftInitialFrameDelay = 16;
    public const int DelayedAutoShiftMainFrameDelay = 6;
    public const int SlideSpeed = 1;
    public static readonly int[] linesToTransition = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 100, 100, 100, 100, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300 };
    public static readonly int[] levelSpeeds = { 48, 43, 38, 33, 28, 23, 18, 13, 8, 6, 5, 5, 5, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1 };
    public static readonly int[] pointTotals = { 40, 100, 300, 1200 };
    public static int score = 0;
    public static int lines = 0;
    public static int level = 0;
    public static int burn = 0;
    public static int drought = 0;
    public static string message = string.Empty;
    public static string song = string.Empty;
    public static bool spawnBlock = true;
    public static bool clearBoard = false;
    public static bool cleanUp = true;
    public static GameObject[][] board = new GameObject[10][];
    public static List<int> linesToClear = new List<int>();
    public static List<GameObject> blocks = new List<GameObject>();

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FrameRate;
        for (var index = 0; index < board.Length; index++)
        {
            board[index] = new GameObject[23];
            for (var subIndex = 0; subIndex < board[index].Length; subIndex++)
                board[index][subIndex] = null;
        }
    }

    public static bool IsLegalMove(Vector3 block)
    {
        return block.x >= -0.001f && block.x <= 9.001f && block.y >= -0.001f && board[Mathf.RoundToInt(block.x)][Mathf.RoundToInt(block.y)] == null;
    }

    public static void Enable(GameObject block)
    {
        block.GetComponent<Fall>().enabled = true;
        block.GetComponent<Slide>().enabled = true;
        block.GetComponent<Rotate>().enabled = true;
    }

    public static void Disable(GameObject block)
    {
        block.GetComponent<Fall>().enabled = false;
        block.GetComponent<Slide>().enabled = false;
        block.GetComponent<Rotate>().enabled = false;
    }
}
