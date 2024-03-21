using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float acceleration = 10f; // Adjust the acceleration rate
    public float deceleration = 20f; // Adjust the deceleration rate
    public float maxSpeed = 10f; // Adjust the maximum speed
    public Animator playerAnim;
    public Transform playerGraphics;
    public float speed = 2f;
    public float upwardIncrement = 0.01f; // Amount to move the player upwards

    private bool isMoving = false; // Flag to indicate whether the player should start moving upwards


    private Rigidbody2D rb;
    private UniversalScrollerSpeed universalScrollerSpeed;
    private float originalSpeed;
    public bool isPlaying = false;

    private void Start()
    {
        gameObject.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        universalScrollerSpeed = FindObjectOfType<UniversalScrollerSpeed>();

        if (universalScrollerSpeed != null)
        {
            originalSpeed = universalScrollerSpeed.universalSpeed;
        }
        else
        {
            Debug.LogError("UNIVERSAL SCROLLER NOT FOUND!");
        }

        // Call a method to activate the player object after a delay
        Invoke("ActivatePlayer", 2f); // Adjust the delay as needed (2 seconds in this example)
    }

    void ActivatePlayer()
    {
        // Activate the player object after the delay
        gameObject.SetActive(true);
    }

private void Update()
    {
        if(isPlaying == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from arrow keys or A/D keys

            // Calculate acceleration based on input direction
            float targetSpeed = moveHorizontal * maxSpeed;
            float accelerationValue = moveHorizontal != 0 ? acceleration : deceleration;

            // Accelerate or decelerate towards the target speed
            float currentSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, accelerationValue * Time.deltaTime);

            // Apply the movement to Rigidbody2D velocity
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Up"))
            {
                universalScrollerSpeed.universalSpeed = originalSpeed / 2;
            }
            else if (Input.GetButtonUp("Up"))
            {
                universalScrollerSpeed.universalSpeed = originalSpeed;
            }

            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            {
                playerAnim.SetBool("isTurning", true);
            }
            else
            {
                playerAnim.SetBool("isTurning", false);
            }

            if (moveHorizontal < 0)
            {
                playerGraphics.localRotation = new Quaternion(0, 180, 0, 0);
            }
            else if (moveHorizontal > 0)
            {
                playerGraphics.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }

        // Check if the player pressed the spacebar to start moving upwards
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        // If the player should start moving, move it upwards
        if (isMoving)
        {
            // Increment the Y position of the player
            transform.position += Vector3.up * upwardIncrement;

            // If the player's Y position reaches 0.0, stop moving upwards
            if (transform.position.y >= 2.0f)
            {
                transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
                isMoving = false;
            }
        }

    }
}
