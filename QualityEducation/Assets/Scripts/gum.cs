using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gum : MonoBehaviour
{
    private PlayerController pc;
    private float speed;
    private float jumpForce;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = pc.speed;
            jumpForce = pc.jumpForce;
            pc.speed *= 0.2f;
            pc.jumpForce *= 0.2f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pc.speed = speed;
            pc.jumpForce = jumpForce;

        }
    }
}
