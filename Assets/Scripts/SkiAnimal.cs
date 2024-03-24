using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiAnimal : MonoBehaviour
{
    private float moveSpeed = 5f;
    public float moveDirection;
    private Rigidbody2D rb;
    private UniversalScrollerSpeed universalScrollerSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        universalScrollerSpeed = FindObjectOfType<UniversalScrollerSpeed>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * moveDirection, universalScrollerSpeed.universalSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponentInParent<PlayerHP>().TakeDamage(1);
            Debug.Log("Player took damage");
        }
    }
}
