using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public static bool canMoveRight = true;
    public static bool canMoveLeft = true;
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;

    void Update()
    {
        if (!GameConditions.gameStarted) return;
       // if (GameConditions.isPlayerCrushed) return;
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(canMoveLeft)
            {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(canMoveRight)
            {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
    }
}