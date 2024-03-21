using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public float platformMoveSpeed;
    public float spawnRate;
    public GameObject platformPrefab;
    public Transform spawnPoint;
    public float spawnRadius;

    private float timer = 0f;
    private JungleTutorial jungleTutorial;

    void Start()
    {
        jungleTutorial = FindObjectOfType<JungleTutorial>();
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (Time.time >= timer)
        {
            SpawnPlatform();
            timer = Time.time + spawnRate;
        }
    }

    void SpawnPlatform()
    {
        float spawnRadiusHalved = spawnRadius / 2;
        float randomYpos = spawnPoint.position.y + Random.Range(-spawnRadiusHalved, spawnRadiusHalved);
        Vector3 randomPos = new Vector3(spawnPoint.position.x, randomYpos, 0);

        GameObject newPlatform = Instantiate(platformPrefab, randomPos, Quaternion.identity);

        newPlatform.GetComponent<Rigidbody2D>().velocity = new Vector2(-platformMoveSpeed, 0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector3(1, spawnRadius, 1));
    }
}
