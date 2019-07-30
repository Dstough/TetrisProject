using UnityEngine;

public class Global : MonoBehaviour
{
    public int[] linesToTransition { get; private set; }
    public int[] levelSpeeds { get; private set; }
    public int[] pointTotals { get; private set; }
    public int score { get; set; }
    public int lines { get; set; }
    public int level { get; set; }
    public int burn { get; set; }
    public int drought { get; set; }

    void Start()
    {
        linesToTransition = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 100, 100, 100, 100, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300 };
        levelSpeeds = new int[] { 48, 43, 38, 33, 28, 23, 18, 13, 8, 6, 5, 5, 5, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1 };
        pointTotals = new int[] { 40, 100, 300, 1200 };
        score = 0;
        lines = 0;
        level = 0;
        burn = 0;
        drought = 0;
    }

    void Update()
    {
        //TODO draw the variables to the screen here.
    }

    public static bool IsInBounds(Vector3 block)
    {
        var leftBound = block.x >= -0.001f;
        var rightBound = block.x <= 9.001f;
        var lowerBound = block.y >= -0.001f;
        return leftBound && rightBound && lowerBound;
    }
}
