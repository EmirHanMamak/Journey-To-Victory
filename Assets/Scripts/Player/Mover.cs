using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float leftRightSpeed = 4f;
    private void FixedUpdate() {
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime, Space.World);
        #if UNITY_ANDROID
        Debug.Log("ONLY ANDROID");
        #endif
        #if UNITY_EDITOR_WIN
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.gameObject.transform.position.x < LevelBoundary.leftSide) return;
            transform.Translate(Vector3.left * leftRightSpeed * Time.fixedDeltaTime);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(this.gameObject.transform.position.x > LevelBoundary.rightSide) return;
            transform.Translate(-Vector3.left * leftRightSpeed * Time.fixedDeltaTime);
        }
        #endif
    }
}
