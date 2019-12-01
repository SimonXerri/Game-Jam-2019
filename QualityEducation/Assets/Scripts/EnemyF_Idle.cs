﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyF_Idle : StateMachineBehaviour
{
    private Collider2D visionCollider;         // collider of vision of enemy
    private Collider2D playerCollider;       // collider of player

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        visionCollider = GameObject.FindGameObjectWithTag("Vision").GetComponent<Collider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        //TODO: Use raycasting?
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (visionCollider && playerCollider.IsTouching(visionCollider)){
            animator.SetBool("seePlayer", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
