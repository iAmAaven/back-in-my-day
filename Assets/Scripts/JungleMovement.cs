using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleMovement : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    public float jumpForce;
    [Header("Ground detection")]
    public Vector2 groundDetectionRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;
    [Header("References")]
    public Transform playerGFX;
    public Transform playerCenter;
    public Animator gfxAnim;
    public AudioSource ridingMoose;

    // PRIVATES
    private Rigidbody2D rb;
    private float movement;
    private bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(feetPos.position, groundDetectionRadius, 0, whatIsGround);
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (isGrounded)
        {
            ridingMoose.UnPause();
            gfxAnim.SetBool("IsJumping", false);
        }
        else
        {
            ridingMoose.Pause();
            gfxAnim.SetBool("IsJumping", true);
        }

        // if (movement < 0)
        // {
        //     playerGFX.localEulerAngles = new Vector3(0, 180, 0);
        // }
        // else if (movement > 0)
        // {
        //     playerGFX.localEulerAngles = new Vector3(0, 0, 0);
        // }
    }

    void FixedUpdate()
    {
        float speed = moveSpeed * movement;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(feetPos.position, groundDetectionRadius);
    }
}
