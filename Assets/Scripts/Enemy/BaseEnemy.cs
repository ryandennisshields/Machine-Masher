using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract is used here so derived classes can use this code
public class BaseEnemy : MonoBehaviour
{
    public static BaseEnemy instance; // Stores the instance, allowing other code to use this code

    private CharacterController controller; // Stores the enemy character controller
    private Vector3 enemyPosition; // Stores the enemy position
    private bool isGrounded; // Stores a bool deciding if the enemy is grounded or not

    private Transform player; // Stores the transform of the player
    private Vector3 playerDirection; // Stores the direction vector of the player

    public float gravity; // Stores an enemy's gravity
    public float speed; // Stores the movement speed
    public float distance; // Stores the minimum distance the enemy will keep from the player
    private float range; // Stores the distance between the player and enemy

    public GameObject bullet; // Stores the bullet object
    public Transform firePosition; // Stores the firing position
    public float bulletDamage; // Stores the bullet's damage
    public float bulletSpeed; // Stores the bullet's speed
    public float bulletDelay; // Stores a delay before the bullet can be fired again
    private float bulletDelayTimer; // Stores a timer for the bullet delay

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Sets "controller" to the Character Controller script
        player = GameObject.Find("Player").transform; // Sets player to a game object with the name "Player", and grabs it's transform
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded; // Set "is grounded" to true or false depending on if the Character Controller recognises the enemy as grounded
        enemyPosition.y += gravity * Time.deltaTime; // Add the gravity to the enemy's y position (times delta time)
        if (isGrounded && enemyPosition.y < 0) // If the enemy is grounded and the enemy's y position is less than 0,
            enemyPosition.y = 0f; // Set the enemy's y position to 0
        controller.Move(enemyPosition * Time.deltaTime); // Keep the enemy's position updated (times delta time)

        playerDirection = (player.transform.position - transform.position).normalized; // Sets the player's direction vector

        Timers(); // Run the Timers function
    }

    // Function for timers
    private void Timers()
    {
        if (bulletDelayTimer > 0) // If the bullet delay is greater than 0,
            bulletDelayTimer -= 1 * Time.deltaTime; // Take away 1 from the bullet delay (times delta time)
    }
    
    // Function for moving towards the player
    public void MoveTowards()
    {
        Vector3 moveTowards = playerDirection * speed * Time.deltaTime; // Set the speed and direction to move towards by getting the player's direction vector times move speed (times delta time)
        moveTowards.y = 0; // Sets the y value of moving towards to null to not effect the gravity
        controller.Move(moveTowards); // Move the enemy towards the player

        range = Vector3.Distance(transform.position, player.position); // Gets the range of the enemy to the player
        if (range < distance)
        { // If the range to the player is less than the minimum distance,
            controller.Move(-moveTowards * 2); // Set move towards to negative doubled to make the enemy move backwards 
        }
    }

    // Function for looking at the player
    public void LookTowards()
    {
        transform.rotation = Quaternion.LookRotation(playerDirection); // Rotate the object to look at the player by getting the look direction from the player's direction vector
    }

    // Function for if an enemy can shoot
    public void Shooting()
    {
        if (bulletDelayTimer <= 0)
        { // If the bullet delay is less than 0,
            GameObject firedBullet = Instantiate(bullet, firePosition.position, firePosition.rotation); // Instatiate a fired bullet using the bullet object, and placing it at the fire position's position and rotation
            Rigidbody rb = firedBullet.GetComponent<Rigidbody>(); // Get the rigidbody of the fired bullet
            rb.AddForce(firePosition.up * bulletSpeed * Time.deltaTime, ForceMode.Impulse); // Add force to the bullet upwards fromt the fire position, multplied by the bullet speed (times delta time)
            bulletDelayTimer = bulletDelay; // Set the bullet delay timer to the bullet delay
        }
    }
}

