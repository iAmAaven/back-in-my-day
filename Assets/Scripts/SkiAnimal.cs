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
}
