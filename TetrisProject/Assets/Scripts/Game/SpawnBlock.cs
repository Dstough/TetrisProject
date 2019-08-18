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

        if (nextBlock.name == "ZBlock(Clone)")
            nextBlock.transform.position = new Vector3(nextBlock.transform.position.x, nextBlock.transform.position.y - 1, nextBlock.transform.position.z);

        Global.blocks.Add(nextBlock);
    }

    void Update()
    {
        if (!Global.spawnBlock)
            return;

        if (currentBlock == null)
        {
            currentBlock = nextBlock;
            currentBlock.transform.position = transform.position;

            if (currentBlock.name != "IBlock(Clone)")
                Global.drought++;
            else
                Global.drought = 0;

            if (currentBlock.name == "ZBlock(Clone)")
                currentBlock.transform.position = new Vector3(currentBlock.transform.position.x, currentBlock.transform.position.y - 1, currentBlock.transform.position.z);

            foreach (Transform child in currentBlock.transform)
                if (!Global.IsLegalMove(child.position))
                {
                    Global.message = "Game Over";
                    Global.spawnBlock = false;
                    return;
                }

            currentBlock.GetComponent<Rotate>().enabled = true;
            currentBlock.GetComponent<Slide>().enabled = true;

            nextBlock = Instantiate(Blocks[Random.Range(0, Blocks.Length)], new Vector3(nextBlockPosition.x, nextBlockPosition.y, 0), Quaternion.identity);

            if(currentBlock.name == nextBlock.name)
            {
                Destroy(nextBlock);
                nextBlock = Instantiate(Blocks[Random.Range(0, Blocks.Length)], new Vector3(nextBlockPosition.x, nextBlockPosition.y, 0), Quaternion.identity);
            }

            if (nextBlock.name == "ZBlock(Clone)")
                nextBlock.transform.position = new Vector3(nextBlock.transform.position.x, nextBlock.transform.position.y - 1, nextBlock.transform.position.z);
            
            Global.blocks.Add(nextBlock);
        }

        if (spawnDropDelay-- > 0)
            return;

        Global.Enable(currentBlock);

        spawnDropDelay = originalSpawnDropDelay;
        currentBlock = null;
        Global.spawnBlock = false;
    }
}
