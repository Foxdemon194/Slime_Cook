using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private CS_Player player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {        
            animator.SetBool(IS_WALKING, player.IsWalking());              
    }
}
