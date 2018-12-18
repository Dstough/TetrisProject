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
        var targetChildrenPositions = new Vector3[4];
        var targetPosition = transform;

        if (Input.GetButtonDown("A") || Input.GetButtonDown("B"))
        {
            if (rotated)
                rotationVector.z = 90;
            else
                rotationVector.z = -90;
        }

        targetPosition.Rotate(rotationVector);
        for (var item = 0; item < targetChildrenPositions.Length; item++)
        {
            var targetChildPoition = Quaternion.AngleAxis(rotationVector.z, Vector3.up) * transform.GetChild(item).position;
            targetChildrenPositions[item] = targetChildPoition;
        }

        if(Global.SafeToMove(targetChildrenPositions))
        {
            transform.Rotate(rotationVector);
            rotated = !rotated;
        }
    }
}
