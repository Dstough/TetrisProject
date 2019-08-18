using UnityEngine;

public class Slide : MonoBehaviour
{

    private int DelayedAutoShiftCurrentFrame = 0;
    private bool skillStop = true;

    void Update()
    {
        var movementVector = new Vector2Int(0, 0);

        if (DelayedAutoShiftCurrentFrame > 0)
            DelayedAutoShiftCurrentFrame -= 1;

        if (Input.GetButtonDown("Left"))
        {
            movementVector.x = Global.SlideSpeed * -1;
            DelayedAutoShiftCurrentFrame = skillStop ? Global.DelayedAutoShiftMainFrameDelay : Global.DelayedAutoShiftInitialFrameDelay;
        }
        else if (Input.GetButtonDown("Right"))
        {
            movementVector.x = Global.SlideSpeed;
            DelayedAutoShiftCurrentFrame = skillStop ? Global.DelayedAutoShiftMainFrameDelay : Global.DelayedAutoShiftInitialFrameDelay;
        }

        if (skillStop)
            skillStop = false;

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
            if (!Global.IsLegalMove(child.position))
                illegalMove = true;

        if (illegalMove)
            transform.position = originalPosition;
    }
}