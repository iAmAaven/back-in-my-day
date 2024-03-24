using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSkiBelow : MonoBehaviour
{
    public float spawnRate, easySpawnRate, normalSpawnRate, highSpawnRate;
    public GameObject[] objectPrefab;
    public Transform spawnPoint;
    public float spawnRadius;
    public bool enableRandomSpawn = false;
    [HideInInspector] public float startSpawnRate;

    private float timer = 0f;

    void Start()
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

            Debug.Log("Obstacle and soulja spawn rate set from PlayerPrefs: " + spawnRate);
        }
        startSpawnRate = spawnRate;

        timer = Time.time + spawnRate - 1f;

        if (enableRandomSpawn)
        {
            timer = Time.time + spawnRate - Random.Range(-1f, 1f);
        }
    }
    void Update()
    {
        if (Time.time >= timer)
        {
            SpawnObject();
            timer = Time.time + spawnRate;
        }
    }

    void SpawnObject()
    {
        float spawnRadiusHalved = spawnRadius / 2;
        float randomXpos = spawnPoint.position.x + Random.Range(-spawnRadiusHalved, spawnRadiusHalved);
        Vector3 randomPos = new Vector3(randomXpos, spawnPoint.position.y, 0);

        GameObject newObject = Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], randomPos, Quaternion.identity);

        Destroy(newObject, 15f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(spawnRadius, 1, 1));
    }
}
