using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHor = Input.GetAxisRaw("Horizontal");

        // Horzontal Movement
        if (moveHor != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveHor, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        rb.transform.Translate(velocity * Time.deltaTime);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder") && Input.GetKey(KeyCode.D))
        {
            
            rb.gravityScale = -1;
            rb.AddForce(Vector2.up * ladderSpeed);
            

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")){
            rb.gravityScale = 1;
        }
        
    }

}


