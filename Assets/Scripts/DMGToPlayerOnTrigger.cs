using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGToPlayerOnTrigger : MonoBehaviour
{
    public int damageToPlayer = 1;
    public AudioClip[] audioClips;
    private AudioSource oneShotAudioSource;

    void Start()
    {
        oneShotAudioSource = GameObject.FindWithTag("OneShotAudio").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerHP>().TakeDamage(damageToPlayer);

            PlayAudio();
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Machete")
        {
            PlayAudio();
            Destroy(gameObject);
        }
    }

    void PlayAudio()
    {
        if (audioClips.Length != 0)
        {
            oneShotAudioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
        }
    }
}
