using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleTreeSpawner : MonoBehaviour
{
    public float minScale = 1f, maxScale = 2f;
    public GameObject[] treePrefabs;
    public Transform spawnPoint;
    public float spawnRate;
    public int orderInLayer;
    public string sortingLayer;
    public float layerSpeed;
    [Range(0f, 1f)] public float brightness;

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
            SpawnTree();
            timer = Time.time + spawnRate + Random.Range(-spawnRate / 2, spawnRate / 2);
        }
    }

    void SpawnTree()
    {
        GameObject newTree = Instantiate(treePrefabs[Random.Range(0, treePrefabs.Length)], spawnPoint.position, Quaternion.identity, transform);

        float randomScale = Random.Range(minScale, maxScale);
        newTree.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        newTree.GetComponent<Rigidbody2D>().velocity = Vector2.left * layerSpeed;

        SpriteRenderer treeSprite = newTree.GetComponentInChildren<SpriteRenderer>();
        treeSprite.sortingOrder = orderInLayer;
        treeSprite.sortingLayerName = sortingLayer;
        treeSprite.color = new Color(brightness, brightness, brightness, 1f);
    }
}
