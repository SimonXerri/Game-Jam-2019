using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AToken : MonoBehaviour
{

    public PlayerController pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //ADD to score

            pc.score += 30;

            Destroy(gameObject);
        }
    }


}
