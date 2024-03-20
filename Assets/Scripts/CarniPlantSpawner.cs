using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarniPlantSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float spawnRate;
    public GameObject carniPlantPrefab;
    private float timer = 0f;

    void Update()
    {
        if (Time.time >= timer)
        {
            SpawnCarniPlant();
            timer = Time.time + spawnRate;
        }
    }

    void SpawnCarniPlant()
    {
        Instantiate(carniPlantPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
