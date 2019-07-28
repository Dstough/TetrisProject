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
        var rotationVector = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("A") || Input.GetButtonDown("B"))
            if (rotated)
                rotationVector.z = 90;
            else
                rotationVector.z = -90;
        
        if (rotationVector.z == 0)
            return;

        var illegalRotate = false;

        transform.Rotate(rotationVector);

        foreach (Transform child in transform)
            if (!Global.IsInBounds(child.position))
                illegalRotate = true;

        if (illegalRotate)
            transform.Rotate(rotationVector * -1);
    }
}
