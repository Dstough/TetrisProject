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
    
    public static bool IsInBounds(Vector3 block)
    {
        var leftBound = block.x >= -0.001f;
        var rightBound = block.x <= 9.001f;
        var lowerBound = block.y >= -0.001f;
        return leftBound && rightBound && lowerBound;
    }
}
