using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Mover mover;
    public int pixelDistToDetect = 20;
    private Vector2 startPos = new Vector2(0f, 0f);
    private bool fingerDown;
    private void Update()
    {
        /*
         * Android Codes
         */
#if UNITY_ANDROID
        //Get Location of where player touch at the screen
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }
        //If player tocuhed screen
        if (fingerDown)
        {
            //If player swipe Up
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Up");
            }
            //If player swipe Down
            else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Down");
            }
            //If player Swipe Right
            else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                mover.Move(true);
                Debug.Log("Swipe Right");
            }
            //If player Swipe Left
            else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                mover.Move(false);
                Debug.Log("Swipe Left");
            }
        }
        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }
#endif
#if UNITY_EDITOR_WIN
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
#endif
    }
}
