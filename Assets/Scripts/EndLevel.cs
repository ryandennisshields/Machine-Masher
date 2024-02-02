using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    // Function for returning to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Loads the "Main Menu" scene
    }
}
