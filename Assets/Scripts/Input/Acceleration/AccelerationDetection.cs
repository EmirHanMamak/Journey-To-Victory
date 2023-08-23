
using UnityEngine;

public class AccelerationDetection : MonoBehaviour
{
  private const float DEADZONE = 0.4f;
  public PlayerMotor playerMotor;
  private void Update()
  {
    if (!GameConditions.gameStarted) return;
    if (GameConditions.isPlayerCrushed) return;
    float horz = Input.acceleration.x;
    float vert = Input.acceleration.y;
    Debug.LogError(horz);
    if (horz > 0 && Mathf.Abs(horz) > DEADZONE)
    {
      playerMotor.MoveLane(true);
    }
    else if (horz < 0 && Mathf.Abs(horz) > DEADZONE)
    {
      playerMotor.MoveLane(false);
    }
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
  }
}
