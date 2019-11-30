using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gum : MonoBehaviour
{
    public PlayerController pc;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pc.speed *= 0.2f;
            pc.jumpForce *= 0.2f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pc.speed = 9f;
            pc.jumpForce = 14f;

        }
    }
}
