using UnityEngine;

public class ClearLines : MonoBehaviour
{
    public int lineClearDelay = 10;
    private int originalLineClearDelay;
    private bool transitioned = false;
    private int transitionCount = 0;

    void Start()
    {
        originalLineClearDelay = lineClearDelay;
    }

    void Update()
    {
        if (Global.linesToClear.Count == 0)
            return;

        if (lineClearDelay == 0)
            for (var index = 0; index < Global.linesToClear.Count; index++)
            {
                for (var y = Global.linesToClear[index]; y < Global.board[0].Length; y++)
                    for (var x = 0; x < Global.board.Length; x++)
                        if (Global.board[x][y] != null)
                        {
                            var block = Global.board[x][y];
                            var newPosition = new Vector3(block.transform.position.x, Mathf.RoundToInt(block.transform.position.y - 1), block.transform.position.z);
                            Global.board[x][y] = null;
                            block.transform.position = newPosition;
                            Global.board[Mathf.RoundToInt(block.transform.position.x)][Mathf.RoundToInt(block.transform.position.y)] = block;
                        }
                for (var subIndex = 0; subIndex < Global.linesToClear.Count; subIndex++)
                    Global.linesToClear[subIndex]--;
            }
        else if (lineClearDelay % 2 == 0)
            foreach (var y in Global.linesToClear)
            {
                var firstBlockLocation = (lineClearDelay - 1) / 2;
                var secondBlockLocation = Global.board.Length - firstBlockLocation - 1;
                Destroy(Global.board[firstBlockLocation][y]);
                Destroy(Global.board[secondBlockLocation][y]);
                Global.board[firstBlockLocation][y] = null;
                Global.board[secondBlockLocation][y] = null;
            }

        if (lineClearDelay-- > 0)
            return;
        else
            lineClearDelay = originalLineClearDelay;


        Global.lines += Global.linesToClear.Count;
        Global.score += Global.pointTotals[Global.linesToClear.Count - 1] * Global.level;

        if (Global.linesToClear.Count < 4)
            Global.burn += Global.linesToClear.Count;
        
        if (transitioned)
            transitionCount += Global.linesToClear.Count;

        if ((!transitioned) & (Global.lines >= Global.linesToTransition[Global.level]))
        {
            transitioned = !transitioned;
            Global.level++;
            transitionCount = Global.lines % Global.linesToTransition[Global.level];
            AudioManager.PlaySound("Level Up");
        }

        if(transitioned && transitionCount >= 10)
        {
            Global.level++;
            transitionCount %= 10;
            AudioManager.PlaySound("Level Up");
        }

        Global.linesToClear.Clear();
        Global.spawnBlock = true;
    }
}