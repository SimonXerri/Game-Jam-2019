using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyToken : MonoBehaviour
{
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //ADD mulitiplyer to score

            pc.score *= 1.2f;

            Destroy(gameObject);
        }
    }
}
