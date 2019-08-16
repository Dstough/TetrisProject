using UnityEngine;

public class Fall : MonoBehaviour
{
    private int currentFallFrame = Global.levelSpeeds[Global.level];
    private int fallScore = 0;

    void Update()
    {
        currentFallFrame--;

        //TODO: This is not fast enough.
        if (Input.GetButton("Down"))
            currentFallFrame--;

        if (currentFallFrame >= 0)
            return;

        currentFallFrame = Global.levelSpeeds[Global.level];

        var movementVector = new Vector2Int(0, -1);
        var illegalMove = false;
        var originalPosition = transform.position;

        transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y + movementVector.y), transform.position.z);

        foreach (Transform child in transform)
            if (!Global.IsLegalMove(child.position))
                illegalMove = true;

        if (Input.GetButton("Down"))
            fallScore++;

        if (!illegalMove)
            return;

        transform.position = originalPosition;

        Global.Disable(gameObject);

        foreach (Transform child in transform)
            Global.board[Mathf.RoundToInt(child.position.x)][Mathf.RoundToInt(child.position.y)] = child.gameObject;

        for (var y = 0; y < Global.board[0].Length; y++)
        {
            var clearThisLine = true;

            for (var x = 0; x < Global.board.Length; x++)
                if (Global.board[x][y] == null)
                    clearThisLine = false;
            
            if (clearThisLine)
                Global.linesToClear.Add(y);
        }

        //TODO: Add bonus time to spawn drop delay based on height of block when locked.
        //Every 3 lines above the first two add an extra frame to the delay.
        //Height 3 - 6 add 1
        //Height 7 - 10 add 2
        //Height 11 - 13 add 3
        //Height 14 - 17 add 4
        //Height 17 - 19 add 5

        Global.spawnBlock = Global.linesToClear.Count == 0;
        Global.score += fallScore;
        fallScore = 0;
    }
}
