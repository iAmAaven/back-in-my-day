using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSkiBelow : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] objectPrefab;
    public Transform spawnPoint;
    public float spawnRadius;

    private UniversalScrollerSpeed universalScrollerSpeed;
    private float timer = 0f;

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

        newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);

        Destroy(newObject, 7f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(spawnRadius, 1, 1));
    }
}
