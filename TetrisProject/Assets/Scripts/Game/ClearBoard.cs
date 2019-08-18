using UnityEngine;

public class ClearBoard : MonoBehaviour
{
    private int frameCount = 20;
    private int originalFrameCount;

    private void Start()
    {
        originalFrameCount = frameCount;
    }

    void Update()
    {
        if (!Global.clearBoard)
            return;

        if (frameCount == 0)
        {
            foreach (var block in Global.blocks)
                Destroy(block);

            for (var index = 0; index < Global.board.Length; index++)
                for (var subIndex = 0; subIndex < Global.board[index].Length; subIndex++)
                    Global.board[index][subIndex] = null;
        }
        else if (frameCount % 2 == 0)
        {
            var firstRowToClear = (frameCount / 2) - 1;
            var secondRowToClear = 19 - firstRowToClear;

            for (var x = 0; x < 10; x++)
            {
                Global.blocks.Remove(Global.board[x][firstRowToClear]);
                Global.blocks.Remove(Global.board[x][secondRowToClear]);
                Destroy(Global.board[x][firstRowToClear]);
                Destroy(Global.board[x][secondRowToClear]);
                Global.board[x][firstRowToClear] = null;
                Global.board[x][secondRowToClear] = null;               
            }
        }

        if (frameCount-- > 0)
            return;

        frameCount = originalFrameCount;
        Global.clearBoard = false;
    }
}
