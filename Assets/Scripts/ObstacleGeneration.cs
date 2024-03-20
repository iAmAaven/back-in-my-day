using System.Collections;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float spawnInterval = 3f;
    public float minSpawnY = -3f; // Minimum y position for spawning
    public float maxSpawnY = 3f;  // Maximum y position for spawning

    public Transform SpawnPoint;

    IEnumerator Start()
    {
        while (true)
        {
            // Choose a random y position for spawning
            float randomY = Random.Range(minSpawnY, maxSpawnY);
            Vector3 spawnPosition = new Vector3(SpawnPoint.position.x, randomY, 0f);

            // Spawn obstacle
            GameObject obstacle = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], spawnPosition, Quaternion.identity);

            // Set obstacle's parent to this spawner to organize hierarchy
            obstacle.transform.parent = transform;

            // Calculate universal speed for obstacles (you can adjust this as needed)
            float universalSpeed = 5f;

            // Move obstacle from right to left
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-universalSpeed, Random.Range(-1f, 1f));

            // Wait for next spawn interval

            // Destroy obstacle when it's off-screen
            Destroy(obstacle, 7f);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
