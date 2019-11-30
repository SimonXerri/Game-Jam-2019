using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompable : MonoBehaviour
{
    public GameObject Enemy;
    private bool dead;
    public float timeLeft = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                Destroy(Enemy);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dead = true;
            //Destroy(Enemy);
        }
    }
}
