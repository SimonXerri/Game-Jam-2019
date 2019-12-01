using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 9;                         // Speed of player
    public float acceleration = 75;                 // Acceleration when starting to walk
    public float deceleration = 70;                 // Deceleration when slowing down
    private Vector3 velocity;                       // To store x and y velocity at the current update

    public float jumpForce;
    private bool isGrounded;
    public bool inAir;

    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;

    public float ladderSpeed = 2f;

    private Animator animator;

    private bool facingRight = true;                // For determining which way the player is currently facing.

    Vector3 initialPos;

    public float score;
    public Text txt;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPos = transform.position;
        score = 100;
        txt = txt.GetComponent<Text>();
        txt.text = "Grade: C";
    }

    void FixedUpdate()
    {
        // Horzontal Movement
        float moveHor = Input.GetAxisRaw("Horizontal");
        if (moveHor != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveHor, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        rb.transform.Translate(velocity * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Abs(velocity.x));

        // If the input is moving the player right and the player is facing left...
        if (moveHor > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveHor < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Update()
    {
        // Vertical Movement
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        animator.SetBool("Ground", isGrounded);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // 
        {
            inAir = true;
            jumpTimeCounter = jumpTime; // reseting
            rb.velocity = Vector2.up * jumpForce;
        }

        if (inAir && Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                inAir = false;
                
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            inAir = false;
        }
        
        // Scores
        if (score > 170)
        {
            txt.text = "Grade: A+";
        }
        else if (170 > score && score >= 160)
        {
            txt.text = "Grade: A";
        }
        else if (160 > score && score >= 150)
        {
            txt.text = "Grade: A-";
        }
        else if (150 > score && score >= 140)
        {
            txt.text = "Grade: B+";
        }
        else if (140 > score && score >= 130)
        {
            txt.text = "Grade: B";
        }
        else if (130 > score && score >= 120)
        {
            txt.text = "Grade: B-";
        }
        else if (120 > score && score >= 110)
        {
            txt.text = "Grade: C+";
        }
        else if (110 > score && score >= 100)
        {
            txt.text = "Grade: C";
        }
        else if (100 > score && score >= 90)
        {
            txt.text = "Grade: C-";
        }
        else if (90 > score && score >= 80)
        {
            txt.text = "Grade: D+";
        }
        else if (80 > score && score >= 70)
        {
            txt.text = "Grade: D";
        }
        else if (70 > score && score >= 60)
        {
            txt.text = "Grade: D-";
        }
        else if (60 > score)
        {
            txt.text = "Grade: F";

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Fall"))
        {
           gameObject.transform.SetPositionAndRotation(initialPos, new Quaternion());
           score -= 20; 

        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        if (!facingRight) gameObject.transform.localScale = new Vector3(-1, 1, 1);
        else gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

}


