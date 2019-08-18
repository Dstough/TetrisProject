using UnityEngine;
using System.Collections.Generic;

public class CleanUpBlocks : MonoBehaviour
{
    private List<GameObject> blocksToRemove = new List<GameObject>();

    void Update()
    {
        if (!Global.cleanUp)
            return;

        foreach (var block in Global.blocks)
            if (block.transform.childCount == 0)
                blocksToRemove.Add(block);
        
        foreach (var block in blocksToRemove)
        {
            Global.blocks.Remove(block);
            Destroy(block);
        }
    }
}
