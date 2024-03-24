using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiObject : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage this object deals
    public bool destroyOnHit = true;
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
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player took damage");
            collider.gameObject.GetComponentInParent<PlayerHP>().TakeDamage(damageAmount);

            if (destroyOnHit == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
