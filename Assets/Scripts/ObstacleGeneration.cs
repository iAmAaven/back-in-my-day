using System.Collections;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float speed;
    public float spawnRate = 3f, easySpawnRate, normalSpawnRate, highSpawnRate;
    public float minSpawnY = -3f; // Minimum y position for spawning
    public float maxSpawnY = 3f;  // Maximum y position for spawning

    public Transform SpawnPoint;
    private IsPlaying isPlaying;

    IEnumerator Start()
    {
        if (PlayerPrefs.GetString("Difficulty") != null)
        {
            switch (PlayerPrefs.GetString("Difficulty"))
            {
                case "easy":
                    spawnRate = easySpawnRate;
                    break;
                case "normal":
                    spawnRate = normalSpawnRate;
                    break;
                case "hard":
                    spawnRate = highSpawnRate;
                    break;
                case "godlike":
                    spawnRate = highSpawnRate;
                    break;
            }
        }

        isPlaying = FindObjectOfType<IsPlaying>();

        while (true)
        {
            if (isPlaying.isGamePlaying)
            {

                float randomY = Random.Range(minSpawnY, maxSpawnY);
                Vector3 spawnPosition = new Vector3(SpawnPoint.position.x, randomY, 0f);

                // Spawn obstacle
                GameObject obstacle = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], spawnPosition, Quaternion.identity, transform);

                // Move obstacle from right to left
                Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-speed, Random.Range(-1f, 1f));
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
