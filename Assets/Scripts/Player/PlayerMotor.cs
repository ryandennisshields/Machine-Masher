using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor instance; // Stores the instance, allowing other code to use this code

    private CharacterController controller; // Stores the player character controller
    private Vector3 playerPosition; // Stores the player's position
    private bool isGrounded; // Stores a bool deciding if the player is grounded or not

    [Header("Movement")]
    public float speed; // Controls the player's move speed
    public float jumpHeight; // Controls the player's jump height
    public float gravity; // Controls the player's gravity (fall speed)
    private float baseSpeed; // Stores the base move speed
    private float baseGravity; // Stores the base gravity
    [Header("Jetpack")]
    public float jetpackForce; // Controls the upward force of the jetpack
    public float jetpackCost; // Controls how much fuel the jetpack costs to use
    [Header("Boost")]
    public float boostSpeed; // Controls the boost speed multiplier
    public float boostCost; // Controls the fuel cost of a boost
    public float boostGravity; // Controls the gravity while boosting
    public float boostDuration; // Controls how long a boost lasts
    public float boostDelay; // Controls how long it takes inbetween boosts
    private float boostDurationTimer; // Stores a timer for the boost duration
    private float boostDelayTimer; // Stores a timer for the boost delay
    [Header("Fuel")]
    public float fuel; // Controls the amount of fuel
    public float fuelRegen; // Controls how fast the fuel regenerates
    public float fuelDelay; // Controls how fast the fuel starts regenerating upon reaching 0 fuel
    private float baseFuel; // Stores the base fuel
    private float fuelDelayTimer; // Stores a timer for the fuel delay

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Sets "controller" to the Character Controller script

        baseSpeed = speed; // Sets the base speed to the speed
        baseGravity = gravity; // Sets the base gravity to the gravity
        baseFuel = fuel; // Sets the base fuel to the fuel
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded; // Set "is grounded" to true or false depending on if the Character Controller recognises the player as grounded

        Timers(); // Run the Timers function
    }

    // Function for timers
    private void Timers()
    {
        if (fuel < baseFuel && fuelDelayTimer <= 0) // If the fuel is less than the base fuel and the fuel delay timer is less than or equal to 0,
            fuel += fuelRegen * Time.deltaTime; // Increase the fuel by the fuel regen (times delta time)
        if (fuel < 0)
        { // If fuel is less than 0,
            fuelDelayTimer = fuelDelay; // Set the fuel delay timer to the fuel delay
            fuel = 0; // Set fuel to 0
        }
        if (fuelDelayTimer > 0) // If the fuel delay timer is greater than 0,
            fuelDelayTimer -= 1 * Time.deltaTime; // Take away 1 from the fuel delay timer (times delta time)
        if (boostDelayTimer > 0) // If the boost delay timer is greater than 0,
            boostDelayTimer -= 1 * Time.deltaTime; // Take away 1 from the boost delay timer (times delta time)
        if (boostDurationTimer > 0) // If the boost duration timer is greater than 0,
            boostDurationTimer -= 1 * Time.deltaTime; // Take away 1 from the boost duration timer (times delta time)
        if (boostDurationTimer <= 0)
        { // If the boost duration timer is less than or equal to 0,
            speed = baseSpeed; // Set the speed to the base speed
            gravity = baseGravity; // Set the gravity to the base gravity
        }
    }

    // Function for moving the player
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero; // Set the move direction to nothing
        moveDirection.x = input.x; // Create a variable to store the left and right move direction
        moveDirection.z = input.y; // Create a variable to store the forward and backward move direction
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); // Move the player dependant on the move direction, times the speed (times delta time)
        playerPosition.y += gravity * Time.deltaTime; // Add the gravity to the player's y position (times delta time)
        if (isGrounded && playerPosition.y < 0) // If the player is grounded and the player's y position is less than 0,
            playerPosition.y = 0f; // Set the player's y position to 0
        controller.Move(playerPosition * Time.deltaTime); // Keep the player's position updated (times delta time)
    }

    // Function for jumping as the player
    public void Jump()
    {
        if (isGrounded)
        { // If the player is grounded,
            playerPosition.y = jumpHeight; // Set the player's y position to the jump height
        }
    }

    // Function for using the jetpack
    public void Jetpack()
    {
        if (fuel > 0)
        { // If fuel is greater than 0
            playerPosition.y = jetpackForce; // Set the player's y position to the jetpack force
            fuel -= jetpackCost * Time.deltaTime; // Take away fuel dependant on the jetpack cost (times delta time)
        }
    }

    // Function for boosting
    public void Boost()
    {
        if (fuel > 0 && boostDelayTimer <= 0)
        { // If fuel is greater than 0 and less than or equal to 0,
            speed *= boostSpeed; // Multiply the speed by the boost speed
            gravity = boostGravity; // Set the gravity to the boost gravity
            boostDelayTimer = boostDelay; // Set the boost delay timer to the boost delay
            boostDurationTimer = boostDuration; // Set the duration timer to the boost duration
            fuel -= boostCost; // Take away fuel dependant on the boost cost
        }
    }
}
