using UnityEngine;

public class Slide : MonoBehaviour
{
    private int DelayedAutoShiftCurrentFrame = 0;

    void Update()
    {
        var movementVector = new Vector2Int(0, 0);

        if (DelayedAutoShiftCurrentFrame > 0)
            DelayedAutoShiftCurrentFrame -= 1;

        if (Input.GetButtonDown("Left"))
        {
            movementVector.x = Global.SlideSpeed * -1;
            DelayedAutoShiftCurrentFrame = Global.DelayedAutoShiftInitialFrameDelay;
        }
        else if (Input.GetButtonDown("Right"))
        {
            movementVector.x = Global.SlideSpeed;
            DelayedAutoShiftCurrentFrame = Global.DelayedAutoShiftInitialFrameDelay;
        }

        if (Input.GetButton("Left") && DelayedAutoShiftCurrentFrame == 0)
        {
            movementVector.x = Global.SlideSpeed * -1;
            DelayedAutoShiftCurrentFrame = Global.DelayedAutoShiftMainFrameDelay;
        }
        else if (Input.GetButton("Right") && DelayedAutoShiftCurrentFrame == 0)
        {
            movementVector.x = Global.SlideSpeed;
            DelayedAutoShiftCurrentFrame = Global.DelayedAutoShiftMainFrameDelay;
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
    }
}
