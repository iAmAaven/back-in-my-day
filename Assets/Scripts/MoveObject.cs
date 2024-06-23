using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float acceleration = 10f; // Adjust the acceleration rate
    public float deceleration = 20f; // Adjust the deceleration rate
    public float maxSpeed = 10f; // Adjust the maximum speed
    public Animator playerAnim;
    public Animator gfxAnim;
    public Animator doorAnim;
    public GameObject trails;
    public float upwardIncrement = 0.01f; // Amount to move the player upwards

    private bool isMoving = false; // Flag to indicate whether the player should start moving upwards

    private Rigidbody2D rb;
    private UniversalScrollerSpeed universalScrollerSpeed;
    private DistanceCounter distanceCounter;
    private float originalSpeed;
    public bool isPlaying = false;
    private ObstaclesSkiBelow[] obstacleGenerators;
    private MooseDiagonal[] animalGenerators;
    private bool changedObstacleSpeed = false;
    private float moveHorizontal;

    private void Start()
    {
        gameObject.SetActive(false);

        distanceCounter = FindObjectOfType<DistanceCounter>();
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
        doorAnim.Play("cottageOpenDoor");
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from arrow keys or A/D keys

            if (Input.GetButtonDown("Up"))
            {
                universalScrollerSpeed.universalSpeed = originalSpeed / 2;
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
            }
            else if (Input.GetButtonUp("Up"))
            {
                universalScrollerSpeed.universalSpeed = originalSpeed;

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
            }
        }

        // Check if the player pressed the spacebar to start moving upwards
        if (isMoving == false && Input.GetButtonDown("Fire1") && FindObjectOfType<JungleTutorial>().isTutorialOn == false)
        {
            gfxAnim.SetBool("Started", true);
            isMoving = true;
        }
    }
    void FixedUpdate()
    {
        // If the player should start moving, move it upwards
        if (isMoving)
        {
            // Increment the Y position of the player
            trails.SetActive(true);
            transform.position += Vector3.up * upwardIncrement;

            // If the player's Y position reaches 0.0, stop moving upwards
            if (transform.position.y >= 2.0f)
            {
                transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
                isMoving = false;
            }
        }

        if (isPlaying)
        {
            if (PlayerPrefs.GetInt("InvertedControls") == 0)
            {
                // Calculate acceleration based on input direction
                float targetSpeed = moveHorizontal * maxSpeed;
                float accelerationValue = moveHorizontal != 0 ? acceleration : deceleration;
                float currentSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, accelerationValue * Time.deltaTime);
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
