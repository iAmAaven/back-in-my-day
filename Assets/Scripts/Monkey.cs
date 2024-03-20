using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;

    [Header("Attack info")]
    public GameObject[] throwableObjects;
    public float throwingTimer;
    public float throwSpeed;

    [Header("Behaviour")]
    public bool isTopMonkey = false;
    public float timeToFirstAttack = 1f;

    [Header("References")]
    public Transform monkeyGFX;
    public Transform throwPoint;

    // HIDDEN
    [HideInInspector] public Transform stopPoint;

    // PRIVATES
    private JungleMovement jungleMovement;
    private bool isPositioned = false;
    private float timer = 0f;

    void Start()
    {
        jungleMovement = FindObjectOfType<JungleMovement>();

        if (isTopMonkey)
        {
            StartCoroutine(MoveTopMonkeyToStopPoint());
        }
        else
        {
            StartCoroutine(MoveSideMonkeyToStopPoint());
        }
    }

    void Update()
    {
        if (jungleMovement)
        {
            if (jungleMovement.transform.position.x > transform.position.x)
            {
                monkeyGFX.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if (jungleMovement.transform.position.x < transform.position.x)
            {
                monkeyGFX.localEulerAngles = new Vector3(0, 180, 0);
            }
        }

        if (isPositioned && Time.time >= timer)
        {
            ThrowObject();
            timer = Time.time + throwingTimer;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Machete")
        {
            Destroy(gameObject);
        }
    }

    void ThrowObject()
    {
        GameObject newObject = Instantiate(throwableObjects[Random.Range(0, throwableObjects.Length)], throwPoint.position, Quaternion.identity);
        Vector2 direction = (jungleMovement.playerCenter.position - transform.position).normalized;

        newObject.GetComponent<Rigidbody2D>().AddForce(direction * throwSpeed, ForceMode2D.Impulse);
    }

    IEnumerator MoveSideMonkeyToStopPoint()
    {
        while (true)
        {
            float speed = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(stopPoint.position.x, transform.position.y, transform.position.z), speed);
            yield return null;

            if (transform.position.x - stopPoint.position.x < 0.001f)
            {
                isPositioned = true;
                break;
            }
        }
    }
    IEnumerator MoveTopMonkeyToStopPoint()
    {
        while (true)
        {
            float speed = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, stopPoint.position.y, transform.position.z), speed);
            yield return null;

            if (transform.position.y - stopPoint.position.y < 0.001f)
            {
                break;
            }
        }
        yield return new WaitForSeconds(Random.Range(timeToFirstAttack - 1f, timeToFirstAttack + 1f));
        isPositioned = true;
    }
}
