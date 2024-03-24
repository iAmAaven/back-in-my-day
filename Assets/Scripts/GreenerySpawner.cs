using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenerySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float spawnRate;
    public GameObject[] plantPrefabs;
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
            SpawnGreenery();
            timer = Time.time + spawnRate;
        }
    }

    void SpawnGreenery()
    {
        Instantiate(plantPrefabs[Random.Range(0, plantPrefabs.Length)], spawnPoint.position, Quaternion.identity, transform);
    }
}
