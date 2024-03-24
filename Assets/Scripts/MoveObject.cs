using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float acceleration = 10f; // Adjust the acceleration rate
    public float deceleration = 20f; // Adjust the deceleration rate
    public float maxSpeed = 10f; // Adjust the maximum speed
    public Animator playerAnim;
<<<<<<< HEAD
    public Transform playerGraphics;
    public float speed = 2f;
    public float upwardIncrement = 0.01f; // Amount to move the player upwards

    private bool isMoving = false; // Flag to indicate whether the player should start moving upwards
=======
    public Animator gfxAnim;
    public Animator doorAnim;
    public GameObject trails;
    public float speed = 2f;
    public float upwardIncrement = 0.01f; // Amount to move the player upwards
>>>>>>> aapo15

    private bool isMoving = false; // Flag to indicate whether the player should start moving upwards

    private Rigidbody2D rb;
    private UniversalScrollerSpeed universalScrollerSpeed;
    private DistanceCounter distanceCounter;
    private float originalSpeed;
    public bool isPlaying = false;
<<<<<<< HEAD
=======
    private ObstaclesSkiBelow[] obstacleGenerators;
    private MooseDiagonal[] animalGenerators;
    private bool changedObstacleSpeed = false;
    private float moveHorizontal;
>>>>>>> aapo15

    private void Start()
    {
        gameObject.SetActive(false);

<<<<<<< HEAD
=======
        distanceCounter = FindObjectOfType<DistanceCounter>();
>>>>>>> aapo15
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
<<<<<<< HEAD
=======
    }

    void ActivatePlayer()
    {
        // Activate the player object after the delay
        gameObject.SetActive(true);
        doorAnim.Play("cottageOpenDoor");
>>>>>>> aapo15
    }

    void ActivatePlayer()
    {
<<<<<<< HEAD
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
=======
        if (isPlaying == true)
        {
            moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from arrow keys or A/D keys
>>>>>>> aapo15

            if (Input.GetButtonDown("Up"))
            {
                universalScrollerSpeed.universalSpeed = originalSpeed / 2;
<<<<<<< HEAD
=======
                if (changedObstacleSpeed == false)
                {
                    obstacleGenerators = FindObjectsOfType<ObstaclesSkiBelow>();
                    animalGenerators = FindObjectsOfType<MooseDiagonal>();

                    foreach (ObstaclesSkiBelow obstacleGenerator in obstacleGenerators)
                    {
                        obstacleGenerator.spawnRate = obstacleGenerator.startSpawnRate * 2;
                    }
                    foreach (MooseDiagonal animalGenerator in animalGenerators)
                    {
                        animalGenerator.spawnRate = animalGenerator.startSpawnRate * 2;
                    }

                    distanceCounter.distanceEverySec = distanceCounter.startDistanceEverySec * 2;
                    Debug.Log("Obstacle spawn rate changed to " + obstacleGenerators[0].spawnRate + " and animal spawn rate to " + animalGenerators[0].spawnRate);
                    changedObstacleSpeed = true;
                }
>>>>>>> aapo15
            }
            else if (Input.GetButtonUp("Up"))
            {
                universalScrollerSpeed.universalSpeed = originalSpeed;
<<<<<<< HEAD
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
=======

                if (changedObstacleSpeed == true)
                {
                    obstacleGenerators = FindObjectsOfType<ObstaclesSkiBelow>();
                    animalGenerators = FindObjectsOfType<MooseDiagonal>();

                    foreach (ObstaclesSkiBelow obstacleGenerator in obstacleGenerators)
                    {
                        obstacleGenerator.spawnRate = obstacleGenerator.startSpawnRate;
                    }
                    foreach (MooseDiagonal animalGenerator in animalGenerators)
                    {
                        animalGenerator.spawnRate = animalGenerator.startSpawnRate;
                    }

                    distanceCounter.distanceEverySec = distanceCounter.startDistanceEverySec;
                    Debug.Log("Obstacle spawn rate changed to " + obstacleGenerators[0].spawnRate + " and animal spawn rate to " + animalGenerators[0].spawnRate);

                    changedObstacleSpeed = false;
                }
            }

            if (rb.velocity.x < -1f)
            {
                playerAnim.SetBool("isTurningRight", true);
                playerAnim.SetBool("isTurningLeft", false);
            }
            else if (rb.velocity.x > 1f)
            {
                playerAnim.SetBool("isTurningRight", false);
                playerAnim.SetBool("isTurningLeft", true);
            }
            else
            {
                playerAnim.SetBool("isTurningRight", false);
                playerAnim.SetBool("isTurningLeft", false);
>>>>>>> aapo15
            }
        }

        // Check if the player pressed the spacebar to start moving upwards
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Space))
        {
=======
        if (isMoving == false && Input.GetButtonDown("Fire1") && FindObjectOfType<JungleTutorial>().isTutorialOn == false)
        {
            gfxAnim.SetBool("Started", true);
>>>>>>> aapo15
            isMoving = true;
        }

        // If the player should start moving, move it upwards
        if (isMoving)
        {
            // Increment the Y position of the player
<<<<<<< HEAD
            transform.position += Vector3.up * upwardIncrement;

            // If the player's Y position reaches 0.0, stop moving upwards
            if (transform.position.y >= 2.0f)
            {
                transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
                isMoving = false;
            }
        }
=======
            trails.SetActive(true);
            transform.position += Vector3.up * upwardIncrement;
>>>>>>> aapo15

            // If the player's Y position reaches 0.0, stop moving upwards
            if (transform.position.y >= 2.0f)
            {
                transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
                isMoving = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (isPlaying)
        {
            if (PlayerPrefs.GetInt("InvertedControls") == 0)
            {
                float targetSpeed = moveHorizontal * maxSpeed;
                float accelerationValue = moveHorizontal != 0 ? acceleration : deceleration;
                float currentSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, accelerationValue * Time.deltaTime);
                // Calculate acceleration based on input direction
                rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            }
            else
            {
                // Calculate acceleration based on input direction
                float targetSpeed = moveHorizontal * -maxSpeed;
                float accelerationValue = moveHorizontal != 0 ? acceleration : deceleration;
                float currentSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, accelerationValue * Time.deltaTime);
                rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            }
        }
    }
}
