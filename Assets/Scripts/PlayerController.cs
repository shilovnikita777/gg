using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 moveVector;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    public float jumpForce;
    
    private bool facingRight = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Walk();
        //Sit();
        Walk();
        Jump();
    }

    private void Update()
    {
        //Walk();
        //Jump();
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGrounded);
        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(transform.up * jumpForce ,ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpForce;
            print(transform.up.x * jumpForce);
        }
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed,rb.velocity.y);
        if (facingRight == false && moveVector.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveVector.x < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
