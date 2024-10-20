using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 10; // Max health
    private int currentHealth;

    public Slider healthSlider;   // Health slider for player health
    public TextMeshProUGUI scoreText;   // Score text UI
    public TextMeshProUGUI gameOverText; // Game Over text UI
    public TextMeshProUGUI winText;      // "You Win" text UI

    private int score = 0;  // Track score
    public bool isPlayerDead = false;
    private int totalEnemies;  // Store the total number of enemies in the game

    // Reference to the spaceship GameObject
    public GameObject spaceShip;  // Assign the spaceship in the Unity Editor

    // Reference to all enemies in the game
    private GameObject[] enemies;

    private void Start()
    {
        currentHealth = playerHealth;  // Initialize player's health
        healthSlider.maxValue = playerHealth;
        healthSlider.value = currentHealth;

        // Find all enemies at the start of the game and set the total number
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;

        // Hide win text at the start
        winText.gameObject.SetActive(false);
    }

    // Public method to handle game over
    public void GameOver()
    {
        Debug.Log("Game Over Triggered");
        isPlayerDead = true;
        spaceShip.GetComponent<ShipMovement>().enabled = false;
        spaceShip.GetComponent<Collider2D>().enabled = false;
        spaceShip.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;  // Pauses the game
    }

    // Method to handle player getting hit
    public void hitPlayer(int damage)
    {
        if (isPlayerDead) return; // If player is already dead, exit the function

        // Reduce current health by the damage amount
        currentHealth -= damage;

        // Clamp the health so it doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, playerHealth);

        // Update the health slider value based on the current health
        healthSlider.value = (float)currentHealth;

        Debug.Log("Player hit! Current Health: " + currentHealth);  // Log the health

        // Check if the slider value has reached zero
        if (healthSlider.value <= 0 && !isPlayerDead)
        {
            GameOver();  // Call the GameOver method when health is 0
        }
    }

    // Other methods remain unchanged...
    // Method to update the score when an enemy is destroyed
    public void AddScore()
    {
        score++;
        scoreText.text = "Destroy : " + score;
        Debug.Log("Score Updated: " + score);  // Log the score for debugging

        // Check if all enemies are destroyed
        totalEnemies--;  // Decrease the total enemies count
        if (totalEnemies <= 0)
        {
            DisplayWin();  // Call win method if no enemies remain
        }
    }

    // Method to display the "You Win" message
    void DisplayWin()
    {
        Debug.Log("All enemies destroyed. You Win!");

        winText.gameObject.SetActive(true);  // Show the "You Win" message
        spaceShip.GetComponent<ShipMovement>().enabled = false;  // Disable ship movement
        Time.timeScale = 0;  // Pause the game after winning
    }

    // Collision detection with enemies
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            hitPlayer(1);
        }
    }
}
