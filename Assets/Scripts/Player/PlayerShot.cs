using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private bool allowHit; // Stores a bool allowing hits
    
    // OnCollisionEnter is called when this object collides with another collider
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); // Destroy this object
        if (other.gameObject.tag == "Enemy")
        { // If the other collider is a game object with the tag "Enemy",
            if (allowHit) return; // If allow hit is true (return stops the running code to make sure it's true),
            allowHit = false; // Set allow hit to false
            other.gameObject.GetComponent<EnemyHealth>().EnemyDamage(PlayerWeapon.instance.bulletDamage); // Take away the enemy's health by the bullet damage of the player
            allowHit = true; // Set allow hit to true
        }
    }
}
