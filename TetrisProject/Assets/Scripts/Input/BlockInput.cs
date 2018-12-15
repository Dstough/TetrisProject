using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    public double speed = 1.0;
    
    private int DelayedAutoShiftCurrentFrame = 0;
    private const int DelayedAutoShiftInitialFrameDelay = 16;
    private const int DelayedAutoShiftMainFrameDelay = 6;

    void Start()
    {
    }

    void Update()
    { 
        if(DelayedAutoShiftCurrentFrame > 0)
            DelayedAutoShiftCurrentFrame -= 1;
        
        if(Input.GetButtonDown("Left"))
        {
            transform.position += new Vector3(-1,0,0);
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftInitialFrameDelay;
        }
        else if(Input.GetButtonDown("Right"))
        {
            transform.position += new Vector3(1,0,0);
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftInitialFrameDelay;
        }

        if(Input.GetButton("Left") && DelayedAutoShiftCurrentFrame == 0)
        {
            transform.position += new Vector3(-1,0,0);
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftMainFrameDelay;
        }
        else if(Input.GetButton("Right") && DelayedAutoShiftCurrentFrame == 0)
        {
            transform.position += new Vector3(1,0,0);
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftMainFrameDelay;
        }

        //TODO: Figure out the correct speed for holding Down.
        //This is too fast, I think its based on the level
        //(maybe twice as fast as current level)
        if(Input.GetButton("Down"))
        {
            transform.position += new Vector3(0,-1,0);
        }
    }
}
