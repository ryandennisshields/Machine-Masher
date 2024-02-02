using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HealthPickup is using the Interactable script
public class HealthPickup : Interactable
{
    public int minRespawnTimer; // Stores the minimum respawn time
    public int maxRespawnTimer; // Stores the maximum respawn time
    private float respawnTimer; // Stores the respawn timer

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0); // Sets the scale to nothing (makes the object invisible/nonexistent)
        respawnTimer = Random.Range(minRespawnTimer, minRespawnTimer + 1); // Set the respawn timer to a random number between the minimum respawn timer and maximum respawn timer (inclusive)
    }

    // Interact is overriden by this code
    protected override void Interact()
    {
        PlayerHealth.instance.PlayerHeal(100); // Heal the player by 100
        transform.localScale = new Vector3(0, 0, 0); // Sets the scale to nothing (makes the object invisible/nonexistent)
        respawnTimer = Random.Range(minRespawnTimer, minRespawnTimer + 1); // Set the respawn timer to a random number between the minimum respawn timer and maximum respawn timer (inclusive)
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer -= 1 * Time.deltaTime; // Decrease the respawn timer by 1 (times delta time)
        if (respawnTimer <= 0)
        { // If the respawn timer is less than or equal to 0,
            transform.localScale = new Vector3(1, 1, 1); // Set the scale back to normal
        }
    }
}
