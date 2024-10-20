using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;   // Drag the Laser prefab here
    public Transform firePoint;      // Position from where the laser will be shot
    public float laserSpeed = 20f;   // Speed of the laser
    public AudioSource laserSound;   // Reference to the AudioSource for the laser sound

    // Update is called once per frame
    void Update()
    {
        // Shooting the laser on Space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // Instantiate the laser and give it velocity
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * laserSpeed; // Adjust depending on your player's direction

        // Play the laser sound
        if (laserSound != null)
        {
            laserSound.Play();
        }
    }
}
