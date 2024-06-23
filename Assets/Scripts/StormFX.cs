using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormFX : MonoBehaviour
{
    public float lightningRate;
    public Animator lightningAnim;
    public AudioSource strikeSound;
    private float timer;

    void Start()
    {
        timer = Time.time + lightningRate;
    }

    void Update()
    {
        if (Time.time >= timer)
        {
            Strike();
            timer = Time.time + lightningRate + Random.Range(-3f, 3f);
        }
    }

    void Strike()
    {
        strikeSound.Play();
        lightningAnim.SetTrigger("LightningStrike");
    }
}
