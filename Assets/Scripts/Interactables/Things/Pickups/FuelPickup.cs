using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HealthPickup is using the Interactable script
public class FuelPickup : Interactable
{
    public int minRespawnTimer; // Stores the minimum respawn time
    public int maxRespawnTimer; // Stores the maximum respawn time
    private float respawnTimer; // Stores the respawn timer

    private float duration; // Stores the duration

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0); // Sets the scale to nothing (makes the object invisible/nonexistent)
        respawnTimer = Random.Range(minRespawnTimer, minRespawnTimer + 1); // Set the respawn timer to a random number between the minimum respawn timer and maximum respawn timer (inclusive)
    }

    // Interact is overriden by this code
    protected override void Interact()
    {
        duration = 5; // Sets the duration to 5
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

        if (duration > 0)
        { // If the duration is greater than 0,
            duration -= 1 * Time.deltaTime; // Decrease the duration by 1 (times delta time)
            PlayerMotor.instance.fuel = 100; // Set the player's fuel to 100
        }
    }
}
