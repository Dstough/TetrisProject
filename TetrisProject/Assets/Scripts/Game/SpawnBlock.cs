using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public  GameObject[] Blocks;

    // Start is called before the first frame update
    void Start()
    {
        //CreateBlock();
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void CreateBlock()
    {
        int index = 4;// Random.Range(0,6);
        Instantiate(Blocks[index], transform.position, Quaternion.identity);
    }
}
