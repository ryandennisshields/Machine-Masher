using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // OnCollisionEnter is called when this object collides with another collider
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); // Destroy this object
        if (other.gameObject.tag == "Player")
        { // If the other collider is a game object with the tag "Player",
            PlayerHealth.instance.PlayerDamage(BaseEnemy.instance.bulletDamage); // Take away the player's health by the bullet damage of the enemy
        }
    }
}
