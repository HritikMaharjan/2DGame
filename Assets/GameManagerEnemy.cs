using UnityEngine;

public class GameManagerEnemy : MonoBehaviour
{
    public bool isPlayerDead = false; // Indicates if the player is dead
    public int playerHealth = 10; // Player's health

    void Update()
    {
        // Example check for player's death
        if (playerHealth <= 0)
        {
            isPlayerDead = true;
            // Add logic to handle player death (e.g., game over screen)
        }
    }

    public void hitPlayer(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player hit! Current health: " + playerHealth);
        if (playerHealth <= 0)
        {
            isPlayerDead = true; // Mark the player as dead
            Debug.Log("Player is dead.");
            // Additional logic for when the player dies can be placed here
        }
    }
}
