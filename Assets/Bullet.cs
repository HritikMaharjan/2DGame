using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Amount of damage the bullet deals
    public float lifetime = 5f; // How long the bullet lasts before disappearing

    private GameManager gameManager; // Reference to GameManager

    void Start()
    {
        // Destroy the bullet after a certain time
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the bullet hits the player's HealthSystem
        HealthSystem playerHealth = hitInfo.GetComponent<HealthSystem>();

        if (playerHealth != null)
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damage);

            // Destroy the bullet after hitting the player
            Destroy(gameObject);

            // Call GameOver method in GameManager
            if (playerHealth.currentHealth <= 0) // Check if the player is dead
            {
                gameManager = FindObjectOfType<GameManager>(); // Find GameManager in the scene
                if (gameManager != null)
                {
                    gameManager.GameOver(); // Call GameOver method
                }
            }
        }
    }
}
