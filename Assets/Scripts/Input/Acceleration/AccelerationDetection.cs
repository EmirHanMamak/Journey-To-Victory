using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.Touch;

public class AccelerationDetection : MonoBehaviour
{
  public Mover mover;
  int pixelDistToDetect = 20;
  private Vector2 startPos = new Vector2(0f, 0f);
  private bool fingerDown;
  private void FixedUpdate()
  {
    if (!GameConditions.gameStarted) return;
    float horz = Input.acceleration.x;
    float vert = Input.acceleration.y;


    mover.gameObject.transform.Translate((mover.leftRightSpeed) * horz * Time.fixedDeltaTime, 0, 0);
    //  if(Input.GetTouch(0).phase)
    //  Debug.LogWarning(Input.acceleration.x + " and " + vert);
    /* if(Input.touchCount > 0)
     {
       Touch touch = Input.GetTouch(0);
       touchBeginX  = touch.position.x;
       if(touch.phase == TouchPhase.Moved)
       {
         if(touchBeginX )
       }
     }*/
    //If player swipe Up

    if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
    {
      startPos = Input.touches[0].position;
      fingerDown = true;
    }
    if (fingerDown)
    {
      if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
      {
        fingerDown = false;
        //Debug.Log("Swipe Up");
      }
    }
    if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
    {
      fingerDown = false;
    }
  }
}
