using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum RotationType { full, half, none }
    public RotationType rotationType;
    private bool rotated = false;
    private bool buttonPressed = false;

    void Update()
    {
        var rotationVector = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("A") && !buttonPressed && rotationType == RotationType.full)
        {
            rotationVector.z = 90;
            buttonPressed = true;
        }
        else if (Input.GetButtonDown("B") && !buttonPressed && rotationType == RotationType.full)
        {
            rotationVector.z = -90;
            buttonPressed = true;
        }
        else if ((Input.GetButton("A") || Input.GetButton("B")) && !buttonPressed && rotationType == RotationType.half)
        {
            if (rotated)
                rotationVector.z = 90;
            else
                rotationVector.z = -90;
            rotated = !rotated;
            buttonPressed = true;
        }

        if (!Input.GetButton("A") && !Input.GetButton("B"))
            buttonPressed = false;

        if (!buttonPressed)
            return;

        var illegalRotate = false;

        transform.Rotate(rotationVector);

        foreach (Transform child in transform)
            if (!Global.IsLegalMove(child.position))
                illegalRotate = true;

        if (illegalRotate)
        {
            transform.Rotate(rotationVector * -1);
            rotated = !rotated;
        }
        else
        {
            if (Input.GetButtonDown("A") || Input.GetButtonDown("B"))
                AudioManager.PlaySound("Rotate");
        }
    }
}
