using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // Stores the instance, allowing other code to use this code
    
    public Slider fuelBar; // Stores the fuel bar
    public Slider healthBar; // Stores the health bar
    public Slider backgroundHealthBar; // Stores the background health bar
    public Canvas HUD; // Stores the heads up display
    public Canvas gameOverScreen; // Stores the game over screen

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = PlayerHealth.instance.maxHealth; // Sets the max health bar's value to the player's max health
        healthBar.value = PlayerHealth.instance.health; // Sets the health bar's value to the player's health
        backgroundHealthBar.maxValue = PlayerHealth.instance.maxHealth; // Sets the background health bar's value to the player's max health
    }

    // Update is called once per frame
    void Update()
    {
        fuelBar.value = PlayerMotor.instance.fuel; // Sets the fuel bar's value to the player's fuel
    }

    // Function for restarting
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads the current active scene (re-loads it)
    }

    // Function for returning to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Loads the "Main Menu" scene
    }
}
