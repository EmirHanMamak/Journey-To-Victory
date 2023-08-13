using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float rightSide = 4.0f;
    public static float leftSide = -4.0f;
    public float internalRight;
    public float internalLeft;



    void Update()
    {
        internalRight = rightSide;
        internalLeft = leftSide;
    }
}
