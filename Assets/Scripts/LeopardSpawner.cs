using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeopardSpawner : MonoBehaviour
{
    public float spawnAfter;
    public GameObject leopardPrefab;
    public Transform spawnPoint, stopPoint;
    private float timer = 0f;
    private JungleTutorial jungleTutorial;
    private bool firstSpawn = false;

    void Start()
    {
        jungleTutorial = FindObjectOfType<JungleTutorial>();
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (firstSpawn && Time.time >= timer)
        {
            SpawnLeopard();
            timer = Time.time + spawnAfter;
        }
        else if (firstSpawn == false)
        {
            float randomTime = Random.Range(6f, 15f);
            Invoke("SpawnLeopard", randomTime);
            timer = Time.time + randomTime;
            firstSpawn = true;
        }
    }

    void SpawnLeopard()
    {
        GameObject newLeopard = Instantiate(leopardPrefab, spawnPoint.position, Quaternion.identity, transform);
        newLeopard.GetComponent<Leopard>().groundPos = stopPoint;
    }
}
