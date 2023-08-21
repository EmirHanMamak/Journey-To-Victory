using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class AccelerationDetection : MonoBehaviour
{
    public Mover mover;
    private void FixedUpdate()
    {
        if (!GameConditions.gameStarted) return;
        float horz = Input.acceleration.x;
        float vert = Input.acceleration.y;
        mover.gameObject.transform.Translate((mover.leftRightSpeed) * horz * Time.fixedDeltaTime, 0, 0);
      //  if(Input.GetTouch(0).phase)
        Debug.LogWarning(Input.acceleration.x + " and " + vert);
    }
}
