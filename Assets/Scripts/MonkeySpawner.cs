using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawner : MonoBehaviour
{
    [Header("Spawn stats")]
    public float spawnRate = 5f;
    public float spawnRadiusX, spawnRadiusY;

    [Header("Points")]
    public Transform topSpawnPoint;
    public Transform sideSpawnPoint;
    public Transform topStopPoint, sideStopPoint;

    [Header("Prefabs")]
    public GameObject sideMonkeyPrefab;
    public GameObject topMonkeyPrefab;

    // PRIVATES
    private float timer = 0f;

    void Update()
    {
        if (Time.time >= timer)
        {
            SpawnMonkey();
            timer = Time.time + spawnRate;
        }
    }

    void SpawnMonkey()
    {
        if (Random.Range(0f, 10f) < 5f)
        {
            float halvedRadius = spawnRadiusX / 2;
            Vector2 randomPos = new Vector2(Random.Range(-halvedRadius, halvedRadius), topSpawnPoint.position.y);

            GameObject newMonkey = Instantiate(topMonkeyPrefab, randomPos, Quaternion.identity, transform);
            newMonkey.GetComponent<Monkey>().stopPoint = topStopPoint;
        }
        else
        {
            float halvedRadius = spawnRadiusY / 2;
            Vector2 randomPos = new Vector2(sideSpawnPoint.position.x, Random.Range(-halvedRadius, halvedRadius));

            GameObject newMonkey = Instantiate(sideMonkeyPrefab, randomPos, Quaternion.identity, transform);
            newMonkey.GetComponent<Monkey>().stopPoint = sideStopPoint;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(topSpawnPoint.position, new Vector2(spawnRadiusX, 1));
        Gizmos.DrawWireCube(sideSpawnPoint.position, new Vector2(1, spawnRadiusY));
    }
}
