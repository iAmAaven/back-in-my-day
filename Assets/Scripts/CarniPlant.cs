using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarniPlant : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float prepareAttackAfter;
    public float attackWait;
    public Animator carniAnim;
    private AudioSource carniSound;
    private Rigidbody2D rb;
    private JungleTutorial jungleTutorial;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jungleTutorial = FindObjectOfType<JungleTutorial>();
        carniSound = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (isAttacking == false && Time.time >= prepareAttackAfter)
        {
            if (carniAnim != null)
            {
                PrepareAttack();
                isAttacking = true;
            }
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

    void PrepareAttack()
    {
        carniAnim.SetTrigger("GettingReady");
        Invoke("Attack", Random.Range(attackWait - .5f, attackWait + .5f));
    }

    void Attack()
    {
        if (carniSound != null)
        {
            carniSound.Play();
        }
        carniAnim.SetTrigger("Attack");
    }
}
