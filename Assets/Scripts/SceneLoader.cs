using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simpleton script for easy access to SceneManager and switching between scenes
/// </summary>

public class SceneLoader : MonoBehaviour
{
    // Private instance of SceneLoader script, non-changeable
    private static SceneLoader _instance;

    // Public Instance function for other scripts to access
    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Scene Loader is set to NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Assign SceneLoader to the current GameObject
        _instance = this; 
    }

    public void LoadNextScene()
    {
        // Load the next scene in the build order
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
