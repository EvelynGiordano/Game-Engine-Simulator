using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol2D : MonoBehaviour
{
    public float speed;
    public bool movingRight;


    private void Start()
    {
        if (movingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        if(!movingRight)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Walls" || collision.collider.tag == "Gold" || collision.collider.tag == "Green")
        {
            Flip();
            
        }
        
    }


    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // Switch the way the player is labelled as facing.
        movingRight = !movingRight;
    }

}
