using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float rightSide = 5.0f;
    public static float leftSide = -5.0f;
    public float internalRight;
    public float internalLeft;



    void Update()
    {
        internalRight = rightSide;
        internalLeft = leftSide;
    }
}
