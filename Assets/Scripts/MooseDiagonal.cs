using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseDiagonal : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] objectPrefab;
    public Transform spawnPoint;
    public float speed;
    public float direction;
    public float spawnRadius;

    private float timer = 0f;

    void Update()
    {
        if (Time.time >= timer)
        {
            SpawnObject();
            timer = Time.time + spawnRate + Random.Range(-3f, 3f);
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

        Destroy(newAnimal, 4f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(1, spawnRadius, 1));
    }
}
