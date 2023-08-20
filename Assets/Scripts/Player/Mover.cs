using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public static bool canMoveRight = true;
    public static bool canMoveLeft = true;
    public static float moverCurrentZPos = 0f;
    public float moveSpeed = 15f;
    public float leftRightSpeed = 15f;
    /*JUMP*/
    public Animator playerObject;
    [SerializeField] float jumpSpeed = 15f;
    public bool comingDown = false;
    private void Start()
    {
        GameConditions.isJumping = false;
        GameConditions.gameEnded = false;
        GameConditions.isPlayerCrushed = false;
        moverCurrentZPos = this.transform.position.z;
    }

    void Update()
    {
        if (!GameConditions.gameStarted) return;
        if (GameConditions.isPlayerCrushed) return;
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        moverCurrentZPos = transform.position.z;
        HorizontalMovment();
        VerticalMovment();
    }
    private void HorizontalMovment()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (canMoveLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (canMoveRight)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
    }
    private void VerticalMovment()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameConditions.isJumping == false)
            {
                GameConditions.isJumping = true;
                StartCoroutine(JumpSequence());
                // playerObject.SetTrigger("isJumping");
            }
        }
        if (GameConditions.isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed, Space.World);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed, Space.World);
            }
        }
    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.25f);
        comingDown = true;
        yield return new WaitForSeconds(0.25f);
        GameConditions.isJumping = false;
        PlayerAnimations.animationPlayOnce = false;
        comingDown = false;
    }
}