using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float minScale = 1f, maxScale = 2f;
    public GameObject[] cloudPrefabs;
    public Transform spawnPoint;
    public float spawnRadius;
    public float spawnRate;
    public int orderInLayer;
    public string sortingLayer;
    public float layerSpeed;
    [Range(0f, 1f)] public float opacity;

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
            SpawnCloud();
            timer = Time.time + spawnRate + Random.Range(-spawnRate / 2, spawnRate / 2);
        }
    }

    void SpawnCloud()
    {
        float radiusHalved = spawnRadius / 2;

        GameObject newCloud = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)],
            new Vector3(spawnPoint.position.x, spawnPoint.position.y + Random.Range(-radiusHalved, radiusHalved), 0), Quaternion.identity, transform);

        float randomScale = Random.Range(minScale, maxScale);
        newCloud.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        newCloud.GetComponent<Rigidbody2D>().velocity = Vector2.left * layerSpeed;

        SpriteRenderer cloudSprite = newCloud.GetComponentInChildren<SpriteRenderer>();
        cloudSprite.sortingOrder = orderInLayer;
        cloudSprite.sortingLayerName = sortingLayer;
        cloudSprite.color = new Color(1f, 1f, 1f, opacity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector2(1, spawnRadius));
    }
}
