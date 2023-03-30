using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pular : MonoBehaviour
{
    private Rigidbody2D rb;
    public int jumpStrengh;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, jumpStrengh), ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("bati");
        }
    }

}
