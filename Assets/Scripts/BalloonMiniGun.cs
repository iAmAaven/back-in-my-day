using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMiniGun : MonoBehaviour
{
    public GameObject minigunBullet;
    public Transform shootPoint;
    public float fireRate;

    private float timer = 0f;

    void Update()
    {
        if (Time.time >= timer && Input.GetButton("Fire1"))
        {
            CreateBullet();
            timer = Time.time + fireRate;
        }
    }

    void CreateBullet()
    {
        Instantiate(minigunBullet, shootPoint.position, Quaternion.identity);
    }
}
