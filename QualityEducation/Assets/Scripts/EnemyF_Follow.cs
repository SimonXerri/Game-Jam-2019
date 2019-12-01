using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyF_Follow : StateMachineBehaviour
{
    public float speed = 10;
    private Vector2 movePosition;
    private Rigidbody2D rb2D;                   // rigid body of enemy
    private Rigidbody2D rb2D_p;                 // rigid body of player

    private Collider2D visionCollider;          // collider of vision of enemy
    private Collider2D playerCollider;          // collider of player

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        visionCollider = GameObject.FindGameObjectWithTag("Vision").GetComponent<Collider2D>();
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        rb2D = animator.GetComponent<Rigidbody2D>();
        rb2D_p = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float step = speed * Time.deltaTime;
        movePosition = Vector2.MoveTowards(rb2D.position, rb2D_p.position, step);
        rb2D.MovePosition(movePosition);

        if (visionCollider && !playerCollider.IsTouching(visionCollider))
        {
            animator.SetBool("seePlayer", false);
        }

        // Update face
        if(rb2D.position.x - rb2D_p.position.x > 0)
        {
            animator.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animator.GetComponent<SpriteRenderer>().flipX = false;
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
