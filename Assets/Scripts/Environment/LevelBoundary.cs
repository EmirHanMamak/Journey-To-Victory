using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "RightBorder")
        {
            //Debug.Log("RightBorder");
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("rightBorder");

                Mover.canMoveRight = false;
                Mover.canMoveLeft = true;
            }
        }
        if (gameObject.tag == "LeftBorder")
        {
            //Debug.Log("RightBorder");
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("LeftBorder");
                Mover.canMoveRight = true;
                Mover.canMoveLeft = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Mover.canMoveRight = true;
        Mover.canMoveLeft = true;
    }
}