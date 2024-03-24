using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloonMovement : MonoBehaviour
{
    public float upForce = 10f;  // Force applied when going up
    public float moveSpeed = 6f;

    public float terminalvelocity = 20f;
    public Animator balloonAnim;
    public float gravityScale = 0.5f;

    private Rigidbody2D rb;
    private IsPlaying isPlaying;
    private float horizontalMove;
    private bool isGoingUp = false;

    void Start()
    {
        isPlaying = FindObjectOfType<IsPlaying>();
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }
    void Update()
    {
        if (isPlaying.isGamePlaying)
            horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Up"))
        {
            balloonAnim.SetBool("IsRising", true);
            isGoingUp = true;
        }
        else
        {
            balloonAnim.SetBool("IsRising", false);
            isGoingUp = false;
        }
    }
    void FixedUpdate()
    {
        if (isPlaying.isGamePlaying == false)
        {
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = gravityScale;
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

            // Check for input to move the balloon up
            if (isGoingUp && rb.velocity.y <= terminalvelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, upForce);
            }
        }
    }
}
