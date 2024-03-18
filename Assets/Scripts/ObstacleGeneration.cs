using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public float obstacleSpeed = 5f;

    IEnumerator Start()
    {
        while (true)
        {
            // Spawn obstacle
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);

            // Set obstacle's parent to this spawner to organize hierarchy
            obstacle.transform.parent = transform;

            // Move obstacle from right to left
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-obstacleSpeed, 0f);

            // Wait for next spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Destroy obstacle when it's off-screen
            Destroy(obstacle);
        }
    }
}
