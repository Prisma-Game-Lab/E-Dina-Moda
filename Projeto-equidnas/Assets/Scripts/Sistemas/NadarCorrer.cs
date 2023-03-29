using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadarCorrer : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(speed,0f));
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Água"))
        {
            
            rb.gravityScale = 0.55f;
            
        }
    }

}
