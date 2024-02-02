using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract is used here so derived classes can use this code
public abstract class Interactable : MonoBehaviour
{
    public bool useEvents; // Stores a bool deciding if the object uses events
    public string promptMessage; // Stores a prompt message string
    
    // Function for basic interaction actions
    public void BaseInteract()
    {
        if (useEvents)
        { // If the interactable object is using events,
            GetComponent<InteractionEvent>().OnInteract.Invoke(); // Activate the events
        }
        Interact(); // Run the Interact function
    }

    protected virtual void Interact()
    {
        // Protected is used to make sure Base Interact is ran first
        // Virtual then allows this function to be replaced by an interactable object's own function
    }
}
