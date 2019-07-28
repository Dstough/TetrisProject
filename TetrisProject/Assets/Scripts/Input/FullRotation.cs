using UnityEngine;
public class FullRotation : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        var rotationVector = new Vector3(0, 0, 0);
        var targetChildrenPositions = new Vector3[4];

        if (Input.GetButtonDown("A"))
            rotationVector.z = 90;
        else if (Input.GetButtonDown("B"))
            rotationVector.z = -90;

        if (rotationVector.z == 0)
            return;

        var safeToRotate = true;

        foreach(Transform child in transform)
        {
            var newPosition = Quaternion.AngleAxis(rotationVector.z, Vector3.up) * child.position;
            if (!Global.IsInBounds(newPosition))
                safeToRotate = false;
        }
        
        if (safeToRotate)
            transform.Rotate(rotationVector);
    }
}