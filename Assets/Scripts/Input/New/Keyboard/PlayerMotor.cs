using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private const float LANE_DISTANCE = 8f;
    private const float TURN_SPEED = 0.0002f;

    private CharacterController characterController;
    public Animator animator;
    private float jumpForce = 8f;
    private float gravity = 12f;
    private float verticalVelocity;
    private float speed = 7f;
    private int desiredLane = 1; // Left = 0, Middle = 1, Right = 2

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!GameConditions.gameStarted) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.SwipeLeft)
        {
            MoveLane(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.SwipeRight)
        {
            MoveLane(true);
        }

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        //Gravity
        bool isGrounded = IsGrounded();
        if (isGrounded) // Grounded
        {
            verticalVelocity = -0.1f;
           // GameConditions.isJumping = true;
            animator.SetBool("isGrounded", isGrounded); 
            if (Input.GetKeyDown(KeyCode.Space) || MobileInput.Instance.SwipeUp)
            {
                //Jump
                verticalVelocity = jumpForce;
                animator.SetTrigger("isJumping");
                StartCoroutine(JumpSequence());
                                animator.SetTrigger("isLanding");
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);
            //GameConditions.isJumping = false;
            //Fast Falling Mecanic
            if (Input.GetKeyDown(KeyCode.Space) || MobileInput.Instance.SwipeDown)
            {
                verticalVelocity = -jumpForce;
                animator.SetTrigger("isLanding");
            }
        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        characterController.Move(moveVector * Time.deltaTime);
        //rotate character to move pos
        Vector3 dir = characterController.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0f;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }
    }
    void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
        /* if(!goingRight)
         {
             desiredLane--;
             if(desiredLane == -1)
             {
                 desiredLane = 0;
             }
         }
         else
         {
             desiredLane++;
             if(desiredLane == 3)
             {
                 desiredLane = 2;
             }
         }*/
    }
    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(characterController.bounds.center.x,
        (characterController.bounds.center.y - characterController.bounds.extents.y) + 0.2f,
        characterController.bounds.center.z), Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1f);
        return (Physics.Raycast(groundRay, 0.2f + 0.1f));
    }
        IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.25f);
        GameConditions.isJumping = false;
        PlayerAnimations.animationPlayOnce = false;
    }
}
