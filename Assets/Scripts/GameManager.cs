using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Stores the instance, allowing other code to use this code

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function for when the player dies
    public void PlayerDeath()
    {
        UIManager.instance.gameOverScreen.gameObject.SetActive(true); // Show the game over screen
        UIManager.instance.HUD.gameObject.SetActive(false); // Disable the HUD
        GameObject.Find("Player").SetActive(false); // Make the player inactive
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy"); // Create an array storing all game objects with the tag "Enemy"
        foreach (GameObject enemies in allEnemies) // For each object in the enemies array,
            enemies.SetActive(false); // Set the enemy inactive
    }
}
