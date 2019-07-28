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
        var movementVector = new Vector2Int(0, 0);

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

        if (movementVector.x == 0)
            return;

        var illegalMove = false;
        var originalPosition = transform.position;

        transform.position = new Vector3(Mathf.Round(transform.position.x + movementVector.x), transform.position.y, transform.position.z);

        foreach (Transform child in transform)
            if (!Global.IsInBounds(child.position))
                illegalMove = true;

        if (illegalMove)
            transform.position = originalPosition;

        movementVector.x = 0;

        //TODO: Figure out the correct speed for holding Down.
        //This is too fast, I think its based on the level
        //(maybe twice as fast as current level)
        if (Input.GetButton("Down"))
        {
            movementVector.y = -1;
        }

        if (movementVector.y == 0)
            return;

        transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y + movementVector.y), transform.position.z);
    }
}
