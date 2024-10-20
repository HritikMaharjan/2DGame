using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20f;  // Speed of the laser
    public GameObject hit_effect;  // Hit effect prefab

    private GameManager gamemanager;

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;  // Make sure gravity doesn't affect the laser
            rb.velocity = transform.up * speed;  // Adjust direction if necessary
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Ensure accurate collision detection for fast objects
        }

        // Slow down the laser temporarily for debugging
        Debug.Log("Laser fired at position: " + transform.position);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Laser hit: " + hitInfo.name); // Log the object being hit

        if (hitInfo.CompareTag("Enemy"))
        {
            // Spawn hit effect
            if (hit_effect != null)
            {
                Instantiate(hit_effect, transform.position, Quaternion.identity);
            }

            Destroy(hitInfo.gameObject);  // Destroy the enemy
            gamemanager.AddScore();  // Update the score
            Destroy(gameObject);  // Destroy the laser
        }
    }
}
