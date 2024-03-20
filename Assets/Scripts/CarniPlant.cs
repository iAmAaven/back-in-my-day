using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarniPlant : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float attackRate;
    public Animator carniAnim;
    private Rigidbody2D rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time >= timer)
        {
            Attack();
            timer = Time.time + attackRate;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Machete")
            Destroy(gameObject);
    }

    void Attack()
    {
        carniAnim.SetTrigger("Attack");
    }
}
