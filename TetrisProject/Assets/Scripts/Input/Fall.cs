using UnityEngine;

public class Fall : MonoBehaviour
{
    private int currentFallFrame = Global.levelSpeeds[Global.level];
    private int fallScore = 0;
    private bool pressedDown = false;

    void Update()
    {
        if (Input.GetButton("Down"))
        {
            currentFallFrame = Mathf.Min(currentFallFrame, 2);
            pressedDown = true;
        }

        if (currentFallFrame-- > 0)
            return;

        if (pressedDown)
        {
            fallScore++;
            pressedDown = false;
        }

        currentFallFrame = Global.levelSpeeds[Global.level];

        var movementVector = new Vector2Int(0, -1);
        var illegalMove = false;
        var originalPosition = transform.position;

        transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y + movementVector.y), transform.position.z);

        foreach (Transform child in transform)
            if (!Global.IsLegalMove(child.position))
                illegalMove = true;

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

        if (transform.position.y < 3)
            SpawnBlock.spawnDropDelay = 10;
        else if (transform.position.y < 7)
            SpawnBlock.spawnDropDelay = 11;
        else if (transform.position.y < 11)
            SpawnBlock.spawnDropDelay = 12;
        else if (transform.position.y < 14)
            SpawnBlock.spawnDropDelay = 13;
        else if (transform.position.y < 17)
            SpawnBlock.spawnDropDelay = 14;
        else
            SpawnBlock.spawnDropDelay = 15;

        Global.spawnBlock = Global.linesToClear.Count == 0;
        Global.score += fallScore;
        fallScore = 0;
    }
}
