using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health points
    public int currentHealth; // Current health points
    public GameObject deadPlayerPrefab;
    public SpriteRenderer playerGraphics;
    private bool isAughFrames = false;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize current health to maximum health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to deal damage to the player
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("currentHealth: " + currentHealth);
        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }

        if (!isAughFrames)
        {
            StartCoroutine(AughFrames());
        }
    }

    // Function to handle player death
    public void Die()
    {
        // Implement player death behavior here
        Debug.Log("Player died");
        Camera.main.GetComponent<AudioListener>().enabled = true;
        FindObjectOfType<LevelHandler>().LevelGameOver();
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