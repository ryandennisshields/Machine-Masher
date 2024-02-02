using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bed is using the Interactable script
public class Bed : Interactable
{
    // Interact is overriden by this code
    protected override void Interact()
    {
        PlayerHealth.instance.PlayerHeal(100); // Heal the player by 100
        GetComponent<Collider>().enabled = false; // Disable the collider (that allows the player to interact)
    }
}
