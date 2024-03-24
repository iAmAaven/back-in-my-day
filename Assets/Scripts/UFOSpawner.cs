using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject ufoPrefab;
    public Transform spawnPoint, sideStopPoint;
    public float spawnRate, easySpawnRate, normalSpawnRate, highSpawnRate;
    public float spawnRadius;
    public bool ufoFound = false;
    private IsPlaying isPlaying;
    private float timer = 0f;

    void Start()
    {
        isPlaying = FindObjectOfType<IsPlaying>();
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
            Debug.Log("UFO spawn rate set from PlayerPrefs: " + spawnRate);
        }
    }
    void Update()
    {
        if (isPlaying.isGamePlaying == false)
            return;

        if (FindObjectOfType<UFO>())
        {
            ufoFound = true;
            return;
        }

        if (ufoFound)
        {
            timer = Time.time + spawnRate;
            ufoFound = false;
        }

        if (Time.time >= timer && ufoFound == false)
        {
            SpawnUFO();
            timer = Time.time + spawnRate;
        }
    }

    void SpawnUFO()
    {
        float radiusHalved = spawnRadius / 2;
        Vector2 randomPos = new Vector2(spawnPoint.position.x,
            spawnPoint.position.y + Random.Range(-radiusHalved, radiusHalved));

        GameObject newUFO = Instantiate(ufoPrefab, randomPos, Quaternion.identity, transform);
        newUFO.GetComponent<UFO>().stopPoint = sideStopPoint;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, new Vector2(1, spawnRadius));
    }
}
