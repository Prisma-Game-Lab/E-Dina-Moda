using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pular : MonoBehaviour
{
    public int Strengh;

    private Rigidbody2D rb;
    private bool grounded;
    private Collider2D[] colliders;

    private bool jumping;
    private bool diving;
    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        diving = false;

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        colliders = this.gameObject.GetComponents<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.gravityScale == 0)
        {
            rb.velocity = Vector2.zero;
        }

        if(transform.position.y >= 0)
        {
            AudioManager.instance.StopSound("mergulhando");

        }

    }

    void OnJump()
    {
        if (grounded)
        {
            grounded = false;
            colliders[0].enabled = true;
            colliders[1].enabled = false;
            jumping = true;

            rb.gravityScale = 1f;
            rb.AddForce(new Vector2(0, Strengh), ForceMode2D.Impulse);
        } 
       
        else if (diving) 
        {
            rb.AddForce(new Vector2(0, Strengh), ForceMode2D.Impulse);
            diving = false;

        }

        AudioManager.instance.Play("saindo_da_agua");
    }

    void OnDive()
    {
        if (grounded)
        {
            grounded = false;
            colliders[0].enabled = false;
            colliders[1].enabled = true;
            diving = true;

            rb.gravityScale = -1f;
            rb.AddForce(new Vector2(0, -Strengh), ForceMode2D.Impulse);


        }
        
        else if (jumping){
            rb.AddForce(new Vector2(0, -Strengh), ForceMode2D.Impulse);
            jumping = false;
        }

        AudioManager.instance.StopSound("saindo_da_agua");
        AudioManager.instance.Play("mergulhando");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) {
            SceneManager.LoadScene("WardrobeFunction");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
            rb.gravityScale = 0;

            jumping = false;
            diving = false;
        }
    }

}
