using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam; // Stores the camera
    public float distance; // Stores the distance of the interact raycast
    public LayerMask mask; // Stores the layer the ray interacts with
    private PlayerUI playerUI; // Stores the Player UI script
    private InputManager inputManager; // Stores the Input Manager script
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam; // Set the camera to the Player Look script's camera
        playerUI = GetComponent<PlayerUI>(); // Set the player UI to the Player UI script
        inputManager = GetComponent<InputManager>(); // Set the input manager to the Input Manager script
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty); // Set all text to be empty
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); // Creates a ray from on the camera's position, rotated to face forwards (same rotation as the camera)
        RaycastHit hitInfo; // Creates a variable to store the information from the ray
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        { // If the raycast hits something within it's distance and using the correct layer,
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            { // If the object has the Interactable script,
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>(); // Creates a variable storing the object's Interactable information
                playerUI.UpdateText(interactable.promptMessage); // Update the prompt message from the Player UI to be the object's prompt message 
                if (inputManager.onFoot.Interact.triggered)
                { // If the interact button is used/triggered,
                    interactable.BaseInteract(); // Run the Base Interact function from the Interactable script
                }
            }
        }
    }
}
