using UnityEngine;

public class CottageBeginningScreen : MonoBehaviour
{
    public float cottageSpeed = 2f;
    public float destroyPositionY = 10f; // Y position where the sprite should be destroyed
    private bool cottageIsMoving = false; // Flag to indicate whether the sprite should start moving upwards
    private MoveObject player;
    private EnableAfterIntro spawner;
    public GameObject fireSpawner;
    
void  Start()
    {
        player = FindObjectOfType<MoveObject>();
        spawner = FindObjectOfType<EnableAfterIntro>();
    }

void Update()
    {
        // Check if the player pressed spacebar to start moving the sprite
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
