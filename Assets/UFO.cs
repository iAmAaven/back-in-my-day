using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float followSpeed;
    public float attackEverySec = 10f, attackCooldown = 5f;
    public float firstAttackAfterSec = 4f;
    private Transform playerPos;
    public Animator ufoAnim;

    private bool isAttacking = false;
    private bool waitedForFirstAttack = false;
    private float timer = 0f;

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (playerPos && isAttacking == false)
        {
            float speed = followSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, playerPos.position.y, transform.position.z), speed);

            if (Time.time >= timer && waitedForFirstAttack)
            {
                StartCoroutine(Shoot());
                timer = Time.time + attackEverySec;
            }

            if (Time.time >= firstAttackAfterSec && waitedForFirstAttack == false)
            {
                waitedForFirstAttack = true;
            }
        }
    }

    IEnumerator Shoot()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);

        ufoAnim.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(-1f + attackCooldown);

        ufoAnim.SetBool("IsAttacking", false);
        isAttacking = false;
    }
}
