using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leopard : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector] public Transform groundPos;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Machete")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (transform.position.y - groundPos.position.y < 0.15f)
        {
            rb.gravityScale = 0f;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }
}
