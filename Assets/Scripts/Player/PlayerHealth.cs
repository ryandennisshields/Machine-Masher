using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; // Stores the instance, allowing other code to use this code

    public float maxHealth; // Stores the max health
    public float health; // Stores the health
    public float chipSpeed; // Stores how quickly the health chips away
    public float lerpTimer; // Stores the lerp timer, which resets after every damage or heal to keep the lerp consistent (between different framerates too)

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth); // Clamps the health to not go below 0 or above the max health
        UpdateHealth(); // Run the Update Health function
    }

    // Function for managing the player's health
    public void UpdateHealth()
    {
        Slider healthBar = UIManager.instance.healthBar; // Sets a health bar variable to the UI's health bar
        Slider backgroundBar = UIManager.instance.backgroundHealthBar; // Set a background health bar variable to the UI's background health bar
        if (backgroundBar.value > health)
        { // If the background bar's value is greater than the health,
            healthBar.value = health; // Set the health bar's value to the health
            backgroundBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red; // Change the background bar's colour to be red
            lerpTimer += Time.deltaTime; // Add delta time to the lerp timer
            float percentComplete = lerpTimer / chipSpeed; // Sets a percent complete value to the lerp timer divided by the chip speed
            percentComplete = percentComplete * percentComplete; // Multiplies percent complete with itself (smooths out the lerp moreso)
            backgroundBar.value = Mathf.Lerp(backgroundBar.value, health, percentComplete); // Set the background bar's value to a lerp between the background bar's current value and health, with the duration of lerp decided by the percent complete
        }
        if (healthBar.value < health)
        { // If the health bar's value is less than the health,
            backgroundBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green; // Change the background bar's colour to be green
            backgroundBar.value = health; // Set the background bar's value to the health
            lerpTimer += Time.deltaTime; // Add delta time to the lerp timer
            float percentComplete = lerpTimer / chipSpeed; // Sets a percent complete value to the lerp timer divided by the chip speed
            percentComplete = percentComplete * percentComplete; // Multiplies percent complete with itself (smooths out the lerp moreso)
            healthBar.value = Mathf.Lerp(healthBar.value, backgroundBar.value, percentComplete); // Set the health bar's value to a lerp between health bar's current value and the background bar's current value, with the duration of lerp decided by the percent complete
        }
        if (health <= 0)
        { // If health is less than or equal to 0,
            GameManager.instance.PlayerDeath(); // Run the "Player Death" function 
        }
    }

    // Function for damaging the player
    public void PlayerDamage(float damage)
    {
        health -= damage; // Take away the health by the damage
        lerpTimer = 0; // Reset the lerp timer
    }

    // Function for healing the player
    public void PlayerHeal(float healAmount)
    {
        health += healAmount; // Add health by the heal amount
        lerpTimer = 0; // Reset the lerp timer
    }
}
