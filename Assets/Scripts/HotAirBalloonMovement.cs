using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloonMovement : MonoBehaviour
{
    public float upForce = 10f;  // Force applied when going up
    public float moveSpeed = 6f;

    public float terminalvelocity = 20f;
    public Animator balloonAnim;

    private Rigidbody2D rb;
    private float horizontalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        // Check for input to move the balloon up
        if (Input.GetButton("Up") && rb.velocity.y <= terminalvelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, upForce);
            balloonAnim.SetBool("IsRising", true);
        }

        if (Input.GetButtonUp("Up"))
        {
            balloonAnim.SetBool("IsRising", false);
        }
    }
}
