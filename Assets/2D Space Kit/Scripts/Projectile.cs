using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject shoot_effect;
    public GameObject hit_effect;

    void Start()
    {
        // Spawn muzzle flash effect
        if (shoot_effect != null)
        {
            Instantiate(shoot_effect, transform.position, Quaternion.identity);
        }

        // Destroy projectile after 5 seconds
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit detected!");

            // Spawn hit effect if available
            if (hit_effect != null)
            {
                Instantiate(hit_effect, transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);  // Destroy enemy
            Destroy(gameObject);  // Destroy laser
        }
    }
}
