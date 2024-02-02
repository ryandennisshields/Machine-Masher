using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function for starting the game
    public void StartGame()
    {
        SceneManager.LoadScene("Level"); // Loads the level scene
    }

    // Function for quitting the game
    public void Exit()
    {
        Application.Quit(); // Quits the game
    }
}
