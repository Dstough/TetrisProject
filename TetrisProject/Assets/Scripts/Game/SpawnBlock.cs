using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public  GameObject[] Blocks;

    void Start()
    {
    }

    void Update()
    {   
    }

    public void CreateBlock()
    {
        int index = 4;// Random.Range(0,6);
        Instantiate(Blocks[index], transform.position, Quaternion.identity);
    }
}
