using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; //variable for the pause menu

    //each function was applied to a respected button
    //pause button
    public void Pause()
    {
        pauseMenu.SetActive(true); //sets the pause menu panel to true, making it visable
        Time.timeScale = 0f; //sets the time scale to 0, making the game freeze

        Debug.Log("pressed");
    }

    //unpause button
    public void Resume()
    {
        pauseMenu.SetActive(false); //sets the pause menu panel to false, making it unvisable
        Time.timeScale = 1f; //sets the time scale back to 1, making the game play

        Debug.Log("pressed");
    }

    //home button
    public void Home(int sceneID)
    {
        Time.timeScale = 1f; //sets the time scale to 1. this is for if the player presses the pause button then goes back to the main menu.
        SceneManager.LoadScene(sceneID); //loads a scene set in the inspector to 0, which is the StartScreen

        Debug.Log("pressed");
    }

    //restart button
    public void Restart(int sceneID)
    {
        SceneManager.LoadScene(sceneID); //loads a scene set in the inspector to 1, which is the Game
    }
}
