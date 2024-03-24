using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.right * bulletSpeed;
    }
}
