using UnityEngine;

public class Fall : MonoBehaviour
{
    private int currentFallFrame = Global.levelSpeeds[Global.level];
    private int fallScore = 0;

    void Update()
    {
        currentFallFrame--;

        if (Input.GetButton("Down"))
            currentFallFrame--;

        if (currentFallFrame >= 0)
            return;

        currentFallFrame = Global.levelSpeeds[Global.level];

        var movementVector = new Vector2Int(0, -1);
        var illegalMove = false;
        var originalPosition = transform.position;

        transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y + movementVector.y), transform.position.z);

        foreach (Transform child in transform)
            if (!Global.IsInBounds(child.position))
                illegalMove = true;

        //TODO: This is not fast enough.
        if (Input.GetButton("Down"))
            fallScore++;

        if (!illegalMove)
            return;
        
        transform.position = originalPosition;

        GetComponent<Fall>().enabled = false;
        GetComponent<Rotate>().enabled = false;
        GetComponent<Slide>().enabled = false;

        Global.spawnBlock = true;
        Global.score += fallScore;
        fallScore = 0;
    }
}
