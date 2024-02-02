using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    // This script doesn't do much on it's own
    // This script is used by Interactable Editor to create an Unity Event when an object has the Event Only Interactable script or has the "use events" bool active from Interactable
    public UnityEvent OnInteract; // Creates a Unity Event called "On Interact"
}
