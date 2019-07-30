﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public enum RotationType { full, half, none }
    public RotationType rotationType;
    private bool rotated { get; set; }
    void Start()
    {
        rotated = false;
    }

    void Update()
    {
        var rotationVector = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("A") && rotationType == RotationType.full)
            rotationVector.z = 90;
        else if (Input.GetButtonDown("B") && rotationType == RotationType.full)
            rotationVector.z = -90;
        else if ((Input.GetButtonDown("A") || Input.GetButtonDown("B")) && rotationType == RotationType.half)
        {
            if (rotated)
                rotationVector.z = 90;
            else
                rotationVector.z = -90;
            rotated = !rotated;
        }

        if (rotationVector.z == 0)
            return;

        var illegalRotate = false;

        transform.Rotate(rotationVector);

        foreach (Transform child in transform)
            if (!Global.IsInBounds(child.position))
                illegalRotate = true;

        if (illegalRotate)
        {
            transform.Rotate(rotationVector * -1);
            rotated = !rotated;
        }
        else
            Global.message = "block rotated";
    }
}
