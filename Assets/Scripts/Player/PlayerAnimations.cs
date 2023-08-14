using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Update() {
        animator.SetBool("gameStarted", GameConditions.gameStarted);
    }

}
