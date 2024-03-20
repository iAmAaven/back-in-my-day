using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private UniversalScrollerSpeed universalScrollerSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        universalScrollerSpeed = FindObjectOfType<UniversalScrollerSpeed>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, universalScrollerSpeed.universalSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("Player took damage");
                Destroy(gameObject); 
        }
    }
}
