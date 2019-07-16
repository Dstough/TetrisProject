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
        var targetPosition = transform;

        if (Input.GetButtonDown("A"))
        {
            rotationVector.z = 90;
        }
        else if (Input.GetButtonDown("B"))
        {
            rotationVector.z = -90;
        }

        targetPosition.Rotate(rotationVector);
        for (var item = 0; item < targetChildrenPositions.Length; item++)
        {
            var targetChildPoition = Quaternion.AngleAxis(rotationVector.z, Vector3.up) * transform.GetChild(item).position;
            targetChildrenPositions[item] = targetChildPoition;
        }

        if (Global.SafeToMove(targetChildrenPositions))
            transform.Rotate(rotationVector);
    }
}
