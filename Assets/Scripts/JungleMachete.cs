using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleMachete : MonoBehaviour
{
    public float attackRate;
    public Animator macheteAnim;
    public AudioSource macheteAudioSource;
    public AudioClip[] macheteClips;

    private float timer = 0f;

    void Update()
    {

        if (Time.time >= timer && Input.GetButtonDown("Fire1"))
        {
            Attack();
            timer = Time.time + attackRate;
        }
    }

    void Attack()
    {
        macheteAudioSource.PlayOneShot(macheteClips[Random.Range(0, macheteClips.Length)]);
        macheteAnim.SetTrigger("Attack");
    }
}
