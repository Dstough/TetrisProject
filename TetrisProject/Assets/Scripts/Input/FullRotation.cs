using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotation : MonoBehaviour
{
    void Start()
    {
    }
    
    void Update()
    {
        if(Input.GetButtonDown("A"))
        {
            transform.Rotate(0,0,90);
        }
        else if(Input.GetButtonDown("B"))
        {
            transform.Rotate(0,0,-90);
        }
    }
}
