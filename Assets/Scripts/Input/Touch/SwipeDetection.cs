using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Mover mover;
    public int pixelDistToDetect = 10;
    private Vector2 startPos = new Vector2(0f, 0f);
    private bool fingerDown;
    private void Update()
    {
        if (GameConditions.isOnBoundery) return;
        startPos = new Vector2(0f, 0f);
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown == true)
        {
            if (Input.mousePosition.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                Debug.Log("Swipe Up");
            }
        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
    }
}
