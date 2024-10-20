using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;    // Reference to the bullet prefab
    public Transform firePoint;        // The position where the bullet is fired from
    public float fireRate = 1f;        // Delay between shots
    public float bulletSpeed = 5f;     // Speed of the bullet

    private float nextFireTime = 0f;
    private Transform player;          // Reference to the player

    void Start()
    {
        // Find the player in the scene (assuming the player has the tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if it's time to fire again
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Set next fire time
        }
    }

    void Shoot()
    {
        if (player == null)
            return;  // If player isn't found, don't shoot

        // Instantiate the bullet at the firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Calculate the direction from the firePoint to the player
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Add velocity to the bullet towards the player
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
}
