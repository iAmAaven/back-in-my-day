using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseDiagonal : MonoBehaviour
{
    public float spawnRate, easySpawnRate, normalSpawnRate, highSpawnRate;
    public GameObject[] objectPrefab;
    public Transform spawnPoint;
    public float speed;
    public float direction;
    public float spawnRadius;
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
            Debug.Log("Animal spawn rate set from PlayerPrefs: " + spawnRate);
        }
        startSpawnRate = spawnRate;

        timer = Time.time + spawnRate + Random.Range(-1.75f, 1.5f);
    }

    void Update()
    {
        if (Time.time >= timer)
        {
            SpawnObject();
            timer = Time.time + spawnRate + Random.Range(-1.75f, 1.5f);
        }
    }

    void SpawnObject()
    {
        float spawnRadiusHalved = spawnRadius / 2;
        float randomYpos = spawnPoint.position.y + Random.Range(-spawnRadiusHalved, spawnRadiusHalved);
        Vector3 randomPos = new Vector3(spawnPoint.position.x, randomYpos, 0);

        GameObject newAnimal = Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], randomPos, Quaternion.identity);
        newAnimal.GetComponent<SkiAnimal>().moveDirection = direction;

        if (direction < 0)
        {
            newAnimal.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        else
        {
            newAnimal.transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
        Destroy(newAnimal, 15f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(1, spawnRadius, 1));
    }
}
