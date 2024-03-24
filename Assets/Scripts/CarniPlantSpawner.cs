using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarniPlantSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float spawnRate, easySpawnRate, normalSpawnRate, highSpawnRate;
    public GameObject[] plantPrefabs;
    private float timer = 0f;
    private JungleTutorial jungleTutorial;

    void Start()
    {
        jungleTutorial = FindObjectOfType<JungleTutorial>();

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
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (Time.time >= timer)
        {
            SpawnCarniPlant();
            timer = Time.time + spawnRate + Random.Range(-1f, 1f);
        }
    }

    void SpawnCarniPlant()
    {
        Instantiate(plantPrefabs[Random.Range(0, plantPrefabs.Length)], spawnPoint.position, Quaternion.identity, transform);
    }
}
