using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHP : MonoBehaviour
{
    public int enemyHitPoints;
    public SpriteRenderer enemyGFX;
    private bool isAughFrames = false;
    public AudioClip deathAudio;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.FindWithTag("OneShotAudio").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "MinigunBullet")
        {
            Destroy(collider.gameObject);
            TakeDamage();

            if (enemyHitPoints <= 0)
            {
                EnemyDeath();
            }
        }
    }

    void TakeDamage()
    {
        enemyHitPoints--;
        if (isAughFrames == false)
            StartCoroutine(AughFrames());
    }

    IEnumerator AughFrames()
    {
        isAughFrames = true;
        for (int i = 0; i < 5; i++)
        {
            enemyGFX.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
            // Player becomes invisible (and invinsible XD) for a second
            enemyGFX.color = new Color32(255, 255, 255, 0);
            yield return new WaitForSeconds(0.1f);
        }

        enemyGFX.color = new Color32(255, 255, 255, 255);
        isAughFrames = false;
    }
    void EnemyDeath()
    {
        if (deathAudio != null)
        {
            audioSource.volume = 0.3f;
            audioSource.clip = deathAudio;
            audioSource.Play();
        }
        Destroy(gameObject);
    }
}
