using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool doorOpen; // Stores a bool deciding if the door is open

    // Function for opening the door
    public void OpenDoor()
    {
        doorOpen = !doorOpen; // Set "door open" to false
        GetComponent<Animator>().SetBool("IsOpen", doorOpen); // Get the Animator component and set the "Is Open" bool to the state of the "door open" bool
    }
}
