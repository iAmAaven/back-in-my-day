using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    [Header("Ground detection")]
    public float groundDetectionRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;

    // PRIVATES
    private Rigidbody2D rb;
    private float movement;
    private bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDetectionRadius, whatIsGround);
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        float speed = moveSpeed * movement;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
