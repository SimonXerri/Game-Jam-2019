using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubber : MonoBehaviour
{
    public float speed = 40;
    private bool hitUpdate;
    public Rigidbody2D rb;



    private void Update()
    {
        if (hitUpdate)
        {
            Vector2 vec = new Vector2(0, 1.0f);
            rb.AddForce(vec * speed, ForceMode2D.Impulse);
            hitUpdate = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitUpdate = true;

        }
    }
}
