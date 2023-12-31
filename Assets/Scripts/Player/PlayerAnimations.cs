
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public static bool animationPlayOnce = false;
    private void Start() {
        animationPlayOnce = false;
    }
    private void Update()
    {
        animator.SetBool("gameStarted", GameConditions.gameStarted);
        if (GameConditions.isPlayerCrushed && animationPlayOnce == false)
        {
            animator.SetTrigger("isPlayerCrushed");
            animationPlayOnce = true;
            //GameConditions.isPlayerCrushed = false;
        }
        if (GameConditions.isJumping && animationPlayOnce == false)
        {
            animationPlayOnce = true;
            animator.SetTrigger("isJumping");
        }
        // GameConditions.isJumping = false;


    }

}
