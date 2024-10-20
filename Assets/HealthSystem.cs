using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health of the player
    public int currentHealth; // Current health of the player

    private GameManager gameManager; // Reference to GameManager

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
        gameManager = FindObjectOfType<GameManager>(); // Find GameManager in the scene
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health to ensure it doesn't go below 0

        Debug.Log("Health Taken: " + damage + ", Current Health: " + currentHealth);

        // Check if health has reached zero
        if (currentHealth <= 0)
        {
            NotifyGameOver(); // Notify the GameManager about player death
        }
    }

    private void NotifyGameOver()
    {
        if (gameManager != null)
        {
            gameManager.GameOver(); // Call GameOver method in GameManager
        }
    }
}
