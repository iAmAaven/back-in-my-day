using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public float dropRate;
    public float moveSpeed;
    public GameObject droppingPrefab;
    public Transform dropPoint;
    public Transform leftEndPoint, rightEndPoint;
    private bool canMove = false;
    private bool isPlaying;
    private bool hasActivated = false;
    private Transform currentEndPoint;
    private float timer = 0f;

    void Start()
    {
        currentEndPoint = leftEndPoint;
    }
    void Update()
    {
        isPlaying = FindObjectOfType<IsPlaying>().isGamePlaying;
        if (isPlaying && canMove == false && hasActivated == false)
        {
            Invoke("StartDragon", 60f);
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
            float speed = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentEndPoint.position, speed);

            if (Vector2.Distance(currentEndPoint.position, leftEndPoint.position) <= 0.1f)
            {
                currentEndPoint = rightEndPoint;
            }
            if (Vector2.Distance(currentEndPoint.position, rightEndPoint.position) <= 0.1f)
            {
                currentEndPoint = leftEndPoint;
            }
        }

    }

    void StartDragon()
    {
        hasActivated = true;
    }
}
