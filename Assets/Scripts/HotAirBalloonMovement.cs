using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloonMovement : MonoBehaviour
{
    public float upForce = 10f;  // Force applied when going up
    public float downForce = 5f; // Force applied when going down

    public float terminalvelocity = 20f;
    public Animator balloonAnim;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void FixedUpdate()
    {
        // Check for input to move the balloon up
        if (Input.GetButton("Up") && rb.velocity.y <= terminalvelocity)
        {
            rb.velocity = Vector2.up * upForce;
            balloonAnim.SetBool("IsRising", true);
        }

        if (Input.GetButtonUp("Up"))
        {
            balloonAnim.SetBool("IsRising", false);
        }
    }
}
