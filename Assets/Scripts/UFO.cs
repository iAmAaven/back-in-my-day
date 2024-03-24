using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UFO : MonoBehaviour
{
    public float moveToPointSpeed;
    public float warningTime, godlikeWarningTime;
    public float followSpeed;
    public float attackRate = 10f, godlikeAttackRate, attackLength = 5f, godlikeAttackLength;
    public float firstAttackAfterSec = 4f;
    public Transform stopPoint;
    private Transform playerPos;
    public Animator ufoAnim;
    public Light2D light2D;
    public float targetIntensity = 5f;

    private bool isAttacking = false;
    private bool waitedForFirstAttack = false;
    private float timer = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("PlayerTarget"))
        {
            playerPos = GameObject.FindWithTag("PlayerTarget").transform;
        }

        firstAttackAfterSec = Time.time + firstAttackAfterSec;

        if (PlayerPrefs.GetString("Difficulty") != null)
        {
            if (PlayerPrefs.GetString("Difficulty") == "godlike")
            {
                attackRate = godlikeAttackRate;
                attackLength = godlikeAttackLength;
                warningTime = godlikeWarningTime;
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
}
