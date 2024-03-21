using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarniPlant : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float attackRate;
    public Animator carniAnim;
    public AudioSource carniSound;
    private Rigidbody2D rb;
    private float timer = 0f;
    private JungleTutorial jungleTutorial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jungleTutorial = FindObjectOfType<JungleTutorial>();
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (Time.time >= timer)
        {
            if (carniAnim != null)
            {
                Attack();
            }

            timer = Time.time + attackRate;
        }
    }
    void FixedUpdate()
    {
        if (jungleTutorial.isTutorialOn)
            return;
        rb.velocity = Vector2.left * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (carniAnim != null && collider.gameObject.tag == "Machete")
            Destroy(gameObject);
    }

    void Attack()
    {
        carniAnim.SetTrigger("Attack");
        Invoke("PlayAudio", 1f);
    }

    void PlayAudio()
    {
        carniSound.Play();
    }
}
