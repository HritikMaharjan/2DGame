using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public GameObject playerTarget;
    public float followSpeed = 10f;
    public int damage = 2;
    public float damageInterval = 1f; // Time between each damage tick

    // Reference to the Game Manager script
    private GameManager gameManager;

    private Coroutine damageCoroutine;

    private void Start()
    {
        // Find the game manager object in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make the enemy follow the player
        if (playerTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.transform.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy collided with Player");

            // Start damage coroutine if not already running
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DealDamageOverTime(collision.gameObject));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Stop the damage coroutine when the enemy stops colliding with the player
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy stopped colliding with Player");

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;  // Reset the coroutine reference
            }
        }
    }

    private IEnumerator DealDamageOverTime(GameObject player)
    {
        while (true)
        {
            Debug.Log("Dealing damage to player...");

            // Stop the coroutine if the player is dead
            if (gameManager.isPlayerDead)
            {
                Debug.Log("Player is dead, stopping damage coroutine.");
                yield break;  // Stop the coroutine
            }

            gameManager.hitPlayer(damage);  // Deal damage to the player
            yield return new WaitForSeconds(damageInterval);  // Wait for the damage interval
        }
    }
}
