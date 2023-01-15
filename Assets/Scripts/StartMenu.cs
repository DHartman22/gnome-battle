using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functionality for each button on start menu
/// </summary>

public class StartMenu : MonoBehaviour
{
    public void OnStartClicked()
    {
        // Load the next scene
        SceneLoader.Instance.LoadNextScene();
    }

    public void OnPracticeClicked()
    {
        // Do nothing
    }

    public void OnExitClicked()
    {
        // Exit the game
        Application.Quit();
    }
}
