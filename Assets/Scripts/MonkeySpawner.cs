using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawner : MonoBehaviour
{
    [Header("Spawn stats")]
    public float spawnRate = 5f;
    public float easySpawnRate, normalSpawnRate, highSpawnRate;
    public float spawnRadiusX, spawnRadiusY;
    public int maxAmountOfMonkeys;

    [Header("Points")]
    public Transform topSpawnPoint;
    public Transform sideSpawnPoint;
    public Transform topStopPoint, sideStopPoint;

    [Header("Prefabs")]
    public GameObject sideMonkeyPrefab;
    public GameObject topMonkeyPrefab;

    // PRIVATES
    private float timer = 0f;
    private JungleTutorial jungleTutorial;
    private bool firstSpawn = false;

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
            Debug.Log("Monkey spawn rate set from PlayerPrefs: " + spawnRate + ", difficulty: " + PlayerPrefs.GetFloat("Difficulty"));
        }
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (firstSpawn && Time.time >= timer)
        {
            if (FindObjectsOfType<Monkey>().Length <= maxAmountOfMonkeys)
            {
                SpawnMonkey();
            }
            timer = Time.time + spawnRate;
        }
        else if (firstSpawn == false)
        {
            float randomTime = Random.Range(3f, 6f);
            Invoke("SpawnMonkey", randomTime);
            timer = Time.time + 10f;
            firstSpawn = true;
        }
    }

    void SpawnMonkey()
    {
        if (Random.Range(0f, 10f) < 5f)
        {
            float halvedRadius = spawnRadiusX / 2;
            Vector2 randomPos = new Vector2(Random.Range(-halvedRadius, halvedRadius), topSpawnPoint.position.y);

            GameObject newMonkey = Instantiate(topMonkeyPrefab, randomPos, Quaternion.identity, transform);
            newMonkey.GetComponent<Monkey>().stopPoint = topStopPoint;
        }
        else
        {
            float halvedRadius = spawnRadiusY / 2;
            Vector2 randomPos = new Vector2(sideSpawnPoint.position.x, Random.Range(-halvedRadius, halvedRadius));

            GameObject newMonkey = Instantiate(sideMonkeyPrefab, randomPos, sideMonkeyPrefab.transform.localRotation, transform);
            newMonkey.GetComponent<Monkey>().stopPoint = sideStopPoint;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(topSpawnPoint.position, new Vector2(spawnRadiusX, 1));
        Gizmos.DrawWireCube(sideSpawnPoint.position, new Vector2(1, spawnRadiusY));
    }
}
