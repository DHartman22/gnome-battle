using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Functionality for choosing a song, difficulty, and starting the game including UI changes
/// 
/// Minor issue: Songs and difficulties can loop from last-to-first, but currently can not loop from first-to-last, due
///    to the use of sliders to represent UI changes, and sliders currently not being able to detect input that would set the 
///    slider below its minimum value.
/// </summary>

public class SongSelection : MonoBehaviour
{
    [Header("Slider Objects")]
    public Slider songSlider;
    public Slider difficultySlider;

    [Header("Text Objects")]
    public TextMeshProUGUI songText;
    public TextMeshProUGUI difficultyText;

    //[SerializeField]
    private Song currentSong = 0;
    //[SerializeField]
    private DifficultyLevel currentDifficulty = 0;

    [Header("Text Lists")]
    [SerializeField]
    private List<string> songNames;
    [SerializeField]
    private List<string> difficultyNames;

    // When player chooses a new song, change text and track what the current song is
    public void ChangeSong()
    {
        // Save the value of the slider when it is changed
        int songIndex = (int)songSlider.value;

        // Has the slider reached the last indexed song?
        if(songIndex == (int)Song.NUM_SONGS)
        {
            // Loop back to the first song and set the current song to the first song
            currentSong = 0;
            songIndex = 0;
            songSlider.value = 0;
        }
        else 
        {
            // Track the current song
            currentSong = (Song)songIndex;
        }
        // Change the text to reflect our current song
        songText.text = songNames[songIndex];
    }

    // When player chooses a new difficulty, change text and track what the current difficulty is
    public void ChangeDifficulty()
    {
        //Debug.Log("Called difficulty function");
        // Save the value of the slider when it is changed
        int difficultyIndex = (int)difficultySlider.value;

        // Has the slider reached the last indexed difficulty?
        if (difficultyIndex == (int)DifficultyLevel.NUM_LEVELS)
        {
            // Loop back to the first difficulty and set the current difficulty
            currentDifficulty = 0;
            difficultyIndex = 0;
            difficultySlider.value = 0;
        }
        else
        {
            // Track the current difficulty
            currentDifficulty = (DifficultyLevel)difficultySlider.value;
        }
        // Change the text to reflect our current difficulty
        difficultyText.text = difficultyNames[difficultyIndex];
    }

    // When Player clicks the "Battle" button, this function will be called and switch to the next scene
    public void OnBattleButton()
    {
        SceneLoader.Instance.LoadNextScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set our slider values to the current song and difficulty
        songSlider.value = (int)currentSong;
        difficultySlider.value = (int)currentDifficulty;

        // Change the slider value to the number of songs
        songSlider.maxValue = (int)Song.NUM_SONGS;
        // Change the slider value to the number of difficulties
        difficultySlider.maxValue = (int)DifficultyLevel.NUM_LEVELS;
    }
}
