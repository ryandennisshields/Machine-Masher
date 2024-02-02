using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Interactable
{
    // Interact is overriden by this code
    protected override void Interact()
    {
        Objective.instance.wave++; // Increase the wave count
        Objective.instance.Positions(); // Run the Positions function
        Objective.instance.Waves(); // Run the Waves function
    }
}
