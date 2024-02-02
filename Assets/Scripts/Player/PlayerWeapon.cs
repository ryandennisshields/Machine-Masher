using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon instance; // Stores the instance, allowing other code to use this code

    public GameObject bullet; // Stores the bullet object
    private Transform weapon; // Stores the weapon's position
    private Transform firePosition; // Stores the firing position
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
        weapon = GameObject.Find("Weapon").transform; // // Sets the weapon to the transform of the object "Weapon"
        firePosition = GameObject.Find("Player Fire Position").transform; // Sets the fire position to the transform of the object "Player Fire Position"
                                                                          // Old code for aligning the weapon fire point to the crosshair
                                                                          //Vector3 weaponPosition = weapon.localPosition; // Gets the weapon's position to the parent
                                                                          //Vector3 firePositionAngle = firePosition.eulerAngles * Mathf.Deg2Rad; // Get the fire position angle and convert it into radians
                                                                          //firePosition.rotation = Quaternion.Euler(firePositionAngle.x * Mathf.Rad2Deg - weaponPosition.x, firePositionAngle.y + weaponPosition.y, firePositionAngle.z + weaponPosition.z); // Set the fire position's rotation to rotate towards the middle (Deg2Rad is used as the amount the y and z will be doesn't work in Unity, as degrees only support 0 to 359 values (but x will work fine, so that's converted back to degrees with Rad2Deg))
    }

    // Update is called once per frame
    void Update()
    {
        Timers(); // Run the timers function
    }

    // Function for timers
    public void Timers()
    {
        if (bulletDelayTimer > 0) // If the bullet delay is greater than 0,
            bulletDelayTimer -= 1 * Time.deltaTime; // Take away 1 from the bullet delay (times delta time)
    }

    public void Shoot()
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
