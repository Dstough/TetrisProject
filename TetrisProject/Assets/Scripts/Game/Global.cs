using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }
    
    public static bool SafeToMove(Vector3[] ChildPositions)
    {
        foreach (var vector in ChildPositions)
        {
            if (!IsInBounds(vector))
                return false;
        }
        return true;
    }
    public static bool IsInBounds(Vector3 block)
    {
        return block.x >= -5.0f && block.x <= 5.0f;
    }
}
