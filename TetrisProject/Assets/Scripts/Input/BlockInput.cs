using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

        var movementVector = new Vector3(0, 0, 0);

        var targetPosition = transform.position;
        var targetChildrenPositions = new Vector3[4];

        if (DelayedAutoShiftCurrentFrame > 0)
            DelayedAutoShiftCurrentFrame -= 1;

        if (Input.GetButtonDown("Left"))
        {
            movementVector.x = -1;
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftInitialFrameDelay;
        }
        else if (Input.GetButtonDown("Right"))
        {
            movementVector.x = 1;
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftInitialFrameDelay;
        }

        if (Input.GetButton("Left") && DelayedAutoShiftCurrentFrame == 0)
        {
            movementVector.x = -1;
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftMainFrameDelay;
        }
        else if (Input.GetButton("Right") && DelayedAutoShiftCurrentFrame == 0)
        {
            movementVector.x = 1;
            DelayedAutoShiftCurrentFrame = DelayedAutoShiftMainFrameDelay;
        }

        //TODO: Figure out the correct speed for holding Down.
        //This is too fast, I think its based on the level
        //(maybe twice as fast as current level)
        if (Input.GetButton("Down"))
        {
            movementVector.y = -1;
        }

        for (var item = 0; item < targetChildrenPositions.Length; item++)
            targetChildrenPositions[item] = transform.GetChild(item).position + movementVector;
        targetPosition += movementVector;

        if (transform.position != targetPosition && Global.SafeToMove(targetChildrenPositions))
        {
            transform.position = targetPosition;
        }
    }
}
