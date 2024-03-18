using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float acceleration = 10f; // Adjust the acceleration rate
    public float deceleration = 20f; // Adjust the deceleration rate
    public float maxSpeed = 10f; // Adjust the maximum speed
    public Animator playerAnim;
    public Transform playerGraphics;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from arrow keys or A/D keys

        // Calculate acceleration based on input direction
        float targetSpeed = moveHorizontal * maxSpeed;
        float accelerationValue = moveHorizontal != 0 ? acceleration : deceleration;

        // Accelerate or decelerate towards the target speed
        float currentSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, accelerationValue * Time.deltaTime);

        // Apply the movement to Rigidbody2D velocity
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        Debug.Log(moveHorizontal);

        if(moveHorizontal != 0)
        {
            playerAnim.SetBool("isTurning", true);
        }

        else
        { 
            playerAnim.SetBool("isTurning", false); 
        }

        if(moveHorizontal < 0)
        {
            playerGraphics.localRotation = new Quaternion(0, 180, 0, 0);
        }

        else if( moveHorizontal > 0)
        {
            playerGraphics.localRotation = new Quaternion(0, 0, 0, 0);
        }

    }
}
