using UnityEngine;
public class FullRotation : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        var rotationVector = new Vector3(0, 0, 0);
        
        if (Input.GetButtonDown("A"))
            rotationVector.z = 90;
        else if (Input.GetButtonDown("B"))
            rotationVector.z = -90;

        if (rotationVector.z == 0)
            return;

        var illegalRotation = false;

        transform.Rotate(rotationVector);

        foreach (Transform child in transform)
            if (!Global.IsInBounds(child.position))
                illegalRotation = true;
        
        if (illegalRotation)
            transform.Rotate(rotationVector * -1);
    }
}