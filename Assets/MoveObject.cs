using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed as needed
    public float minX = -11f; // Minimum X position
    public float maxX = 11f;  // Maximum X position
    public float minY = -4f; // Minimum Y position
    public float maxY = 4f;  // Maximum Y position
    public float brakeMultiplier = 0.5f; // Multiplier for braking (how much speed decreases when braking)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from arrow keys or A/D keys

        // Create a movement vector with only horizontal component
        Vector2 movement = new Vector2(moveHorizontal, 0f) * speed;

        // Apply the movement to Rigidbody2D velocity
        rb.velocity = movement;

        // Clamp the position to stay within the defined area
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;

        // Check for braking when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Decrease the speed by the brakeMultiplier
            speed *= brakeMultiplier;
        }
    }
}