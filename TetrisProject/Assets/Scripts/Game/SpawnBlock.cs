using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] Blocks;
    public int spawnDropDelay = 10;
    private int originalSpawnDropDelay;
    private GameObject currentBlock;
    private GameObject nextBlock;
    private Vector2Int nextBlockPosition = new Vector2Int(15, 14);

    void Start()
    {
        originalSpawnDropDelay = spawnDropDelay;
        nextBlock = Instantiate(Blocks[Random.Range(0, Blocks.Length)], new Vector3(nextBlockPosition.x, nextBlockPosition.y, 0), Quaternion.identity);
    }

    void Update()
    {
        if (!Global.spawnBlock)
            return;

        if (currentBlock == null)
        {
            currentBlock = nextBlock;
            currentBlock.transform.position = transform.position;
            currentBlock.GetComponent<Rotate>().enabled = true;

            foreach (Transform child in currentBlock.transform)
                if (!Global.IsLegalMove(child.position))
                {
                    Global.message = "Game Over";
                    Global.spawnBlock = false;
                    return;
                }

            nextBlock = Instantiate(Blocks[Random.Range(0, Blocks.Length)], new Vector3(nextBlockPosition.x, nextBlockPosition.y, 0), Quaternion.identity);
            
        }

        spawnDropDelay--;

        if (spawnDropDelay >= 0)
            return;

        Global.Enable(currentBlock);

        spawnDropDelay = originalSpawnDropDelay;
        currentBlock = null;
        Global.spawnBlock = false;
    }
}
