using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloonMovement : MonoBehaviour
{
    public float upForce = 10f;  // Force applied when going up
    public float downForce = 5f; // Force applied when going down

    public float terminalvelocity = 20f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Check for input to move the balloon up
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y <= terminalvelocity)
        {
            rb.AddForce(Vector2.up * upForce, ForceMode2D.Force);
        }
    }
}
