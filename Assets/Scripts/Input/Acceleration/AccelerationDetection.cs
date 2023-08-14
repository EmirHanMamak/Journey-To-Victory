using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationDetection : MonoBehaviour
{
        public Mover mover;
        private void FixedUpdate() {
            if(!GameConditions.gameStarted) return;
            float horz = Input.acceleration.x;
            float vert = Input.acceleration.y;
            mover.gameObject.transform.Translate((mover.moveSpeed * 4f) * Input.acceleration.x * Time.fixedDeltaTime, 0, 0);
        Debug.LogWarning(Input.acceleration.x);
        }
}
