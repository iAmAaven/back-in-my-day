using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth, maxHealthEasy = 8, maxHealthNormal = 5, maxHealthHard = 3, maxHealthGodlike = 1; // Maximum health points
    public int currentHealth; // Current health points
    public GameObject deadPlayerPrefab;
    public SpriteRenderer playerGraphics;
    public AudioSource hurtAudio;
    public AudioClip[] audioClips;
    public HPBar hPBar;

    private LevelHandler levelHandler;
    private bool isAughFrames = false;


    // Start is called before the first frame update
    void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();
        hPBar = FindObjectOfType<HPBar>();
        // Initialize current health to maximum health
        if (PlayerPrefs.GetString("Difficulty") != null)
        {
            Debug.Log("Set difficulty from PlayerPrefs: " + PlayerPrefs.GetString("Difficulty"));

            switch (PlayerPrefs.GetString("Difficulty"))
            {
                case "easy":
                    maxHealth = maxHealthEasy;
                    break;
                case "normal":
                    maxHealth = maxHealthNormal;
                    break;
                case "hard":
                    maxHealth = maxHealthHard;
                    break;
                case "godlike":
                    maxHealth = maxHealthGodlike;
                    break;
            }
        }

        currentHealth = maxHealth;
        hPBar.CreateHPBar(maxHealth);
    }

    // Function to deal damage to the player
    public void TakeDamage(int damageAmount)
    {
        if (!isAughFrames && levelHandler.levelHasBeenCompleted == false)
        {
            currentHealth -= damageAmount;
            hPBar.UpdateHPBar(currentHealth);
            // Check if the player is dead
            if (currentHealth <= 0)
            {
                Die();
            }

            hurtAudio.clip = audioClips[Random.Range(0, audioClips.Length)];
            hurtAudio.Play();

            StartCoroutine(AughFrames());
        }
    }

    // Function to handle player death
    public void Die()
    {
        // Implement player death behavior here
        Debug.Log("Player died");
        levelHandler.LevelGameOver();
        Instantiate(deadPlayerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        // You can reset player position, show game over screen, etc.
    }

    IEnumerator AughFrames()
    {
        isAughFrames = true;
        for (int i = 0; i < 5; i++)
        {
            playerGraphics.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
            // Player becomes invisible (and invinsible XD) for a second
            playerGraphics.color = new Color32(255, 255, 255, 0);
            yield return new WaitForSeconds(0.1f);
        }

        playerGraphics.color = new Color32(255, 255, 255, 255);
        isAughFrames = false;
    }
}