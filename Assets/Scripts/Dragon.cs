using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public float dropRate;
    public float moveSpeed;
    public float directionChangeTimer;
    public float startDragonTimer = 60f;
    public GameObject droppingPrefab;
    public Transform dropPoint;
    public Transform leftEndPoint, rightEndPoint;
    public Transform dragonGFX;
    public Collider2D hitCollider;
    public AudioSource dragonAudio;
    private bool canMove = false;
    private bool hasActivated = false;
    private Transform currentEndPoint;
    private float timer = 0f;
    private IsPlaying isPlaying;
    private bool isChangingDir = false;

    void Start()
    {
        hitCollider.enabled = false;
        currentEndPoint = leftEndPoint;
        isPlaying = FindObjectOfType<IsPlaying>();
    }
    void Update()
    {
        if (isPlaying.isGamePlaying && canMove == false && hasActivated == false)
        {
            Invoke("StartDragon", startDragonTimer);
            hasActivated = true;
        }

        if (canMove && Time.time >= timer)
        {
            Instantiate(droppingPrefab, dropPoint.position, Quaternion.identity);
            timer = Time.time + dropRate;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (!dragonAudio.isPlaying)
            {
                dragonAudio.Play();
            }
            float speed = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentEndPoint.position, speed);

            if (isChangingDir == false)
            {
                if (currentEndPoint == leftEndPoint)
                {
                    StartCoroutine(ChangeDirection(rightEndPoint));
                    dragonGFX.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    StartCoroutine(ChangeDirection(leftEndPoint));
                    dragonGFX.localEulerAngles = new Vector3(0, 180, 0);
                }
            }
        }

    }

    IEnumerator ChangeDirection(Transform endPoint)
    {
        isChangingDir = true;
        yield return new WaitForSeconds(directionChangeTimer);
        currentEndPoint = endPoint;
        isChangingDir = false;
    }

    void StartDragon()
    {
        Debug.Log("Dragon activated");
        hitCollider.enabled = true;
        canMove = true;
    }
}
