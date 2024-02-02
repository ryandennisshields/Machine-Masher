using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI promptText; // Stores the prompt text
    
    // Function for updating the text
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage; // Set the prompt text to the prompt message
    }
}
