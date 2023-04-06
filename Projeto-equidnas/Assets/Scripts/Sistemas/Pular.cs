using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pular : MonoBehaviour
{
    public int Strengh;

    private Rigidbody2D rb;
    private bool grounded;
    private Collider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    void OnJump()
    {
        if (grounded)
        {
            grounded = false;
            colliders[0].enabled = true;
            colliders[1].enabled = false;

            rb.gravityScale = 1f;
            rb.AddForce(new Vector2(0, Strengh), ForceMode2D.Impulse);
        }
    }

    void OnDive()
    {
        if (grounded)
        {
            grounded = false;
            colliders[0].enabled = false;
            colliders[1].enabled = true;

            rb.gravityScale = -1f;
            rb.AddForce(new Vector2(0, -Strengh), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("bati");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
            rb.gravityScale = 0;
        }
    }

}
