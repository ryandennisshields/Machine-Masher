using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Objective : MonoBehaviour
{
    public static Objective instance; // Stores the instance, allowing other code to use this code

    public int wave; // Stores the wave
    public int enemiesDestroyed; // Stores the amount of enemies destroyed

    private GameObject player; // Stores the player
    private GameObject bed; // Stores the bed
    private GameObject waveText; // Stores the wave text

    [Header("Objects")]
    public GameObject platform; // Stores the platform
    public GameObject enemy; // Stores the enemy
    public GameObject healthPickup; // Stores the health pickup
    public GameObject fuelPickup; // Stores the fuel pickup

    [Header("Positions")]
    public List<Vector3> platformPositions; // Stores a list of platform positions
    public List<Vector3> platformRotations; // Stores a list of platform rotations
    public List<Vector3> enemyPositions; // Stores a list of enemy positions
    public List<Vector3> pickupPostions; // Stores a list of pickup positions

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // Set the player object to a object with the name "Player"
        bed = GameObject.Find("Bed"); // Set the bed object to a object with the name "Bed"
        waveText = GameObject.Find("Wave Text"); // Set the wave text to a object with the name "Wave Text"
    }
    
    // Function for setting positions
    public void Positions()
    {
        switch (wave)
        { // Create a switch for the waves
            // ARENA DIMENSIONS
            // X 60 Y 30 Z 60 
            case 1: // If wave is equal to 1,
                // Adds multiple positions to the respective lists depending on the number of things that spawn in the wave
                platformPositions.Add(new Vector3(0, 2, -20));
                platformRotations.Add(new Vector3(90, 0, 0));
                enemyPositions.Add(new Vector3(0, 2, 0));
                enemyPositions.Add(new Vector3(20, 2, 0));
                enemyPositions.Add(new Vector3(-20, 2, 0));
                pickupPostions.Add(new Vector3(0, 2, 0));
                player.transform.position = new Vector3(0, 2, -25); // Move the player down to the arena
                break; // Stop this case
            case 2: // If wave is equal to 2,
                // Adds multiple positions to the respective lists depending on the number of things that spawn in the wave
                platformPositions.Add(new Vector3(0, 15, -25));
                platformPositions.Add(new Vector3(0, 15, 25));
                platformPositions.Add(new Vector3(0, 15, 0));
                platformPositions.Add(new Vector3(-25, 15, 0));
                platformPositions.Add(new Vector3(25, 15, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                enemyPositions.Add(new Vector3(0, 2, 0));
                enemyPositions.Add(new Vector3(20, 2, 0));
                enemyPositions.Add(new Vector3(-20, 2, 0));
                enemyPositions.Add(new Vector3(0, 2, 20));
                enemyPositions.Add(new Vector3(0, 2, -20));
                pickupPostions.Add(new Vector3(0, 17, 25));
                player.transform.position = new Vector3(0, 17, -25); // Move the player down to the arena
                break; // Stop this case
            case 3: // If wave is equal to 3,
                // Adds multiple positions to the respective lists depending on the number of things that spawn in the wave
                platformPositions.Add(new Vector3(0, 10, 25));
                platformPositions.Add(new Vector3(5, 10, 25));
                platformPositions.Add(new Vector3(-5, 10, 25));
                platformPositions.Add(new Vector3(0, 2, -20));
                platformPositions.Add(new Vector3(15, 2, -10));
                platformPositions.Add(new Vector3(-15, 2, -10));
                platformPositions.Add(new Vector3(0, 15, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(0, 0, 0));
                platformRotations.Add(new Vector3(90, 0, 0));
                platformRotations.Add(new Vector3(90, 0, 30));
                platformRotations.Add(new Vector3(90, 0, -30));
                platformRotations.Add(new Vector3(0, 0, 0));
                enemyPositions.Add(new Vector3(-5, 12, 25));
                enemyPositions.Add(new Vector3(-2.5f, 12, 25));
                enemyPositions.Add(new Vector3(0, 12, 25));
                enemyPositions.Add(new Vector3(2.5f, 12, 25));
                enemyPositions.Add(new Vector3(5, 12, 25));
                enemyPositions.Add(new Vector3(-5, 2, 20));
                enemyPositions.Add(new Vector3(-2.5f, 2, 20));
                enemyPositions.Add(new Vector3(0, 2, 20));
                enemyPositions.Add(new Vector3(2.5f, 2, 20));
                enemyPositions.Add(new Vector3(5, 2, 20));
                pickupPostions.Add(new Vector3(0, 17, 0));
                player.transform.position = new Vector3(0, 2, -25); // Move the player down to the arena
                break; // Stop this case


        }
    }

    // Function for waves
    public void Waves()
    {
        int rotations = 0; // Create a variable to store the current platform rotation
        foreach (Vector3 platformPos in platformPositions)
        { // For each platform position in the list,
            GameObject newPlatform = Instantiate(platform, platformPos, platform.transform.rotation); // Instantiate a platform using the platform position
            newPlatform.transform.rotation = Quaternion.Euler(platformRotations[rotations]); // Rotate the newly created platform using the platform rotation
            rotations++; // Move to the next rotation in the list
        }
        foreach (Vector3 enemyPos in enemyPositions)
        { // For each enemy position in the list,
            Instantiate(enemy, enemyPos, enemy.transform.rotation); // Instantiate an enemy using the enemy positions 
        }
        foreach (Vector3 pickupPos in pickupPostions)
        { // For each pickup position in the list,
            float pickuptoSpawn = Random.Range(1, 2 + 1); // Get a random number between 1 and 2 (inclusive)
            if (pickuptoSpawn == 1) // If the pickup to spawn is 1,
                Instantiate(healthPickup, pickupPos, healthPickup.transform.rotation); // Instantiate a health pickup using the pickup positions 
            if (pickuptoSpawn == 2) // If the pickup to spawn is 2,
                Instantiate(fuelPickup, pickupPos, fuelPickup.transform.rotation); // Instantiate a fuel pickup using the pickup positions 
        }
    } 
    
    // Function for when a wave is complete
    public void WaveComplete()
    {
        if (enemiesDestroyed == enemyPositions.Count)
        { // If the amount of enemies destroyed equals the amount of enemies in a wave,
            player.transform.position = new Vector3(0, 15, -65); // Move the player back to the room
            bed.GetComponent<Collider>().enabled = true; // Re-enable the bed
            int waveNumber = wave + 1; // Create a wave number integer using the wave + 1
            waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + waveNumber; // Set the wave text to be "Wave" + the wave number

            GameObject[] allPlatforms = GameObject.FindGameObjectsWithTag("Platform"); // Create an array storing all game objects with the tag "Platform"
            foreach (GameObject platforms in allPlatforms) // For each object in the platform array,
                Destroy(platforms); // Destroy the platforms
            GameObject[] allPickups = GameObject.FindGameObjectsWithTag("Pickup"); // Create an array storing all game objects with the tag "Pickup"
            foreach (GameObject pickups in allPickups) // For each object in the pickup array,
                Destroy(pickups); // Destroy the pickups
            
            // Clears all of the lists
            platformPositions.Clear();
            platformRotations.Clear();
            enemyPositions.Clear();
            pickupPostions.Clear();

            enemiesDestroyed = 0; // Set enemies destroyed back to 0

            if (wave == 3)
            { // If wave is equal to 3,
                SceneManager.LoadScene("EndLevel"); // Loads the end level scene
            }
        }
    }
}
