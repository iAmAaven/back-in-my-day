using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallBush : MonoBehaviour
{
    public float moveSpeed = 7f;
    public AudioClip[] bushSounds;
    private AudioSource oneShotAudioSource;
    private Rigidbody2D rb;
    private JungleTutorial jungleTutorial;

    void Start()
    {
        oneShotAudioSource = GameObject.FindWithTag("OneShotAudio").GetComponent<AudioSource>();
        jungleTutorial = FindObjectOfType<JungleTutorial>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (jungleTutorial.isTutorialOn)
            return;
        rb.velocity = Vector2.left * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Machete")
        {
            if (!oneShotAudioSource.isPlaying)
            {
                oneShotAudioSource.PlayOneShot(bushSounds[Random.Range(0, bushSounds.Length)]);
            }
            Destroy(gameObject);
        }
    }
}
