using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    private float actualHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        actualHealth = health;
    }

    void Update()
    {
        if (actualHealth <= 0)
        { // If health is less than or equal to 0,
            Objective.instance.enemiesDestroyed++; // Add one more enemy destroyed
            Objective.instance.WaveComplete(); // Check if the wave is complete
            Destroy(gameObject); // Destroy this game object
        }
    }

    // Function for enemy damage
    public void EnemyDamage(float damage)
    {
        actualHealth -= damage; // Take away health dependant on the damage
    }
}
