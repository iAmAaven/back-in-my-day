using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float acceleration = 10f; // Adjust the acceleration rate
    public float deceleration = 20f; // Adjust the deceleration rate
    public float maxSpeed = 10f; // Adjust the maximum speed
    public Animator playerAnim;
    public Transform playerGraphics;

    private Rigidbody2D rb;
    private UniversalScrollerSpeed universalScrollerSpeed;
    private float originalSpeed;

    private void Start()
    {
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
}
