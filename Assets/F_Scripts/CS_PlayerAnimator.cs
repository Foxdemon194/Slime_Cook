using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlayerAnimator : MonoBehaviour
{
    private const string SPEED = "Speed";

    [SerializeField] private CS_Player player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player.IsWalking())
        {
            animator.SetFloat(SPEED, .5f);
        }
        else
        {
            animator.SetFloat(SPEED, 0f);
        }
        
    }
}
