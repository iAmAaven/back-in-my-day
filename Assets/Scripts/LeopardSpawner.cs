using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeopardSpawner : MonoBehaviour
{
    public float spawnRate, easySpawnRate, normalSpawnRate, highSpawnRate;
    public GameObject leopardPrefab;
    public Transform spawnPoint, stopPoint;
    private float timer = 0f;
    private JungleTutorial jungleTutorial;
    private bool firstSpawn = false;
    private bool isAboutToSpawnFirst = false;
    private float randomTime;

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
            Debug.Log("Leopard spawn rate set from PlayerPrefs: " + spawnRate);
        }
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (firstSpawn && Time.time >= timer)
        {
            SpawnLeopard();
            timer = Time.time + spawnRate + Random.Range(-1f, 1f);
        }
        else if (firstSpawn == false && isAboutToSpawnFirst == false)
        {
            isAboutToSpawnFirst = true;
            randomTime = Random.Range(6f, 15f);
            Invoke("SpawnLeopard", randomTime);
        }
    }

    void SpawnLeopard()
    {
        timer = Time.time + randomTime;
        firstSpawn = true;
        GameObject newLeopard = Instantiate(leopardPrefab, spawnPoint.position, Quaternion.identity, transform);
        newLeopard.GetComponent<Leopard>().groundPos = stopPoint;
    }
}
