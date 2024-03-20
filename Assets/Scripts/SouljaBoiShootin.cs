using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouljaBoiShootin : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] objectPrefab;
    public float direction;
    public Transform bulletSpawn;

    private float timer = 0f;

    void Update()
    {
        if (Time.time >= timer)
        {
            SpawnObject();
            timer = Time.time + spawnRate + Random.Range(-1f, 1f);
        }
    }

    void SpawnObject()
    {
        GameObject newBullet = Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], bulletSpawn.position, Quaternion.identity);
        newBullet.GetComponent<SouljaBullet>().moveDirection = direction;
        Destroy(newBullet, 15f);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
    }
}
