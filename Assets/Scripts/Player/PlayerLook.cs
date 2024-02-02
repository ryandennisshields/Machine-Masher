using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public static PlayerLook instance; // Stores the instance, allowing other code to use this code

    public Camera cam; // Stores the camera
    private float yRotation = 0f; // Stores the y rotation

    public float xSensitivity; // Stores the sensitivity horizontally
    public float ySensitivity; // Stores the sensitivity vertically

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets instance to use this code
    }

    // Function for when the player looks around
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x; // Create a variable to store the mouse's horizontal input
        float mouseY = input.y; // Create a variable to store the mouse's vertical input
        yRotation -= (mouseY * Time.deltaTime) * ySensitivity; // Set the y rotation by taking the negative of the vertical input, times the vertical sensitivity (times delta time)
        yRotation = Mathf.Clamp(yRotation, -80f, 80f); // Clamps the y rotation to never go below -80 and higher than 80
        cam.transform.localRotation = Quaternion.Euler(yRotation, 0, 0); // Move the camera's vertical rotation to the y rotation
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity); // Rotate the player by the horizontal input, times the horizontal sensitivity (times delta time)
    }
}
