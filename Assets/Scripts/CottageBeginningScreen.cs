using UnityEngine;

public class CottageBeginningScreen : MonoBehaviour
{
    public float cottageSpeed = 2f;
    public float destroyPositionY = 10f;
    private bool cottageIsMoving = false; // Flag to indicate whether the sprite should start moving upwards
    private MoveObject player;
    private EnableAfterIntro spawner;
    public GameObject fireSpawner;
    private JungleTutorial tutorial;

    void Start()
    {
        tutorial = FindObjectOfType<JungleTutorial>();
        player = FindObjectOfType<MoveObject>();
        spawner = FindObjectOfType<EnableAfterIntro>();
    }

    void Update()
    {
        // Check if the player pressed spacebar to start moving the sprite
        if (tutorial.isTutorialOn == false && cottageIsMoving == false && player.gameObject.activeSelf && Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<IsPlaying>().isGamePlaying = true;
            cottageIsMoving = true;
            fireSpawner.SetActive(true);
        }

        // If the sprite should start moving, move it upwards
        if (cottageIsMoving)
        {
            transform.Translate(Vector2.up * cottageSpeed * Time.deltaTime);

            // Check if the sprite is beyond the destroy position
            if (transform.position.y > destroyPositionY)
            {
                // Destroy the sprite
                Destroy(gameObject);
                player.isPlaying = true;
                spawner.isPlaying = true;
            }
        }
    }
}
