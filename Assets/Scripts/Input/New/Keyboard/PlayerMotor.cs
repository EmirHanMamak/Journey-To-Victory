using System.Collections;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    private const float LANE_DISTANCE = 6f;
    private const float TURN_SPEED = 0.0002f;
    public static float moverCurrentZPos = 0f;
    private CharacterController characterController;
    public Animator animator;
    public float jumpForce = 8f;
    public float gravity = 20f;
    public float verticalVelocity;
    public float speed = 7f;
    private int desiredLane = 1; // Left = 0, Middle = 1, Right = 2

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        AudioListener.volume = PlayerPrefs.GetInt(TagList.settingsSoundVolume) / 80f;
        animator.SetBool(TagList.isFastRunning, false);
        GameConditions.isJumping = false;
        GameConditions.gameEnded = false;
        GameConditions.isPlayerCrushed = false;
        moverCurrentZPos = this.transform.position.z;
    }
    private void Update()
    {
        if (!GameConditions.gameStarted) return;
        if (GameConditions.isPlayerCrushed) return;
        moverCurrentZPos = transform.position.z;
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
        speed += 0.001f;
        animator.SetFloat("slowRunMultiplier", animator.GetFloat("slowRunMultiplier") + 0.00005f);
        if(speed >= 30)
        {
            animator.SetBool(TagList.isFastRunning, true);
        }
    }
    public void MoveLane(bool goingRight)
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
        yield return new WaitForSeconds(0.01f);
        GameConditions.isJumping = false;
        PlayerAnimations.animationPlayOnce = false;
    }
}
