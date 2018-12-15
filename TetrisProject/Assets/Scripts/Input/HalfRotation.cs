using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfRotation : MonoBehaviour
{
    public bool rotated = false;

    void Start()
    { 
    }

    void Update()
    {
        if(Input.GetButtonDown("A") || Input.GetButtonDown("B"))
        {
            if(rotated)
                transform.Rotate(0,0,90);
            else
                transform.Rotate(0,0,-90);
            rotated = !rotated;
        }
    }
}
