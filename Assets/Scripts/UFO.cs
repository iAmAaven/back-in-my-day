using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UFO : MonoBehaviour
{
    [Header("Normal attack stats")]
    public GameObject bulletPrefab;
    public float basicAttackInterval, basicAttackIntervalGodlike;

    [Header("Behaviour")]
    public float moveToPointSpeed;
    public float followSpeed;

    [Header("Special attack stats")]
    public float warningTime, godlikeWarningTime;
    public float attackRate = 10f, godlikeAttackRate, attackLength = 5f, godlikeAttackLength;
    public float firstAttackAfterSec = 4f;
    public float targetIntensity = 5f;

    [Header("References")]
    public Transform firePoint;
    public Transform stopPoint;
    public Animator ufoAnim;
    public Light2D light2D;

    private Transform playerPos;
    private bool isAttacking = false;
    private bool waitedForFirstAttack = false;
    private float timer = 0f;
    private float normalAttackTimer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("PlayerTarget"))
        {
            playerPos = GameObject.FindWithTag("PlayerTarget").transform;
        }

        normalAttackTimer = Time.time + basicAttackInterval;
        firstAttackAfterSec = Time.time + firstAttackAfterSec;

        if (PlayerPrefs.GetString("Difficulty") != null)
        {
            if (PlayerPrefs.GetString("Difficulty") == "godlike")
            {
                attackRate = godlikeAttackRate;
                attackLength = godlikeAttackLength;
                warningTime = godlikeWarningTime;
                basicAttackInterval = basicAttackIntervalGodlike;
            }
        }
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
                timer = Time.time + attackRate + Random.Range(-1f, 1f);
            }

            if (Time.time >= firstAttackAfterSec && waitedForFirstAttack == false)
            {
                waitedForFirstAttack = true;
            }

            if (Time.time >= normalAttackTimer)
            {
                normalAttackTimer = Time.time + basicAttackInterval;
                NormalAttack();
            }
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x - stopPoint.position.x > 0.01f)
        {
            rb.velocity = Vector2.left * moveToPointSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator Shoot()
    {
        isAttacking = true;
        StartCoroutine(SmoothIntensityChange());

        yield return new WaitForSeconds(warningTime);

        ufoAnim.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(attackLength);

        normalAttackTimer = Time.time + basicAttackInterval;
        ufoAnim.SetBool("IsAttacking", false);
        isAttacking = false;
        ResetLight();
    }

    void ResetLight()
    {
        light2D.intensity = 0f;
    }

    private IEnumerator SmoothIntensityChange()
    {
        float currentIntensity;
        float timer2 = 0f;

        while (timer2 < warningTime)
        {
            timer2 += Time.deltaTime;
            currentIntensity = Mathf.Lerp(0f, targetIntensity, timer2 / warningTime);
            light2D.intensity = currentIntensity;
            yield return null; // Wait for the next frame
        }

        // Ensure we reach the target intensity exactly
        light2D.intensity = targetIntensity;
    }

    void NormalAttack()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
