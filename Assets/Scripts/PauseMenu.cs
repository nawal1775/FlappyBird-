using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class takes care of the pause menu that appears by pressing escape, when to resume and when to load the main scene .
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //resume when the pressing escape then resume button 
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //pause the game when pressing escape 
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        //freeze the game 
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //load the main menu 
        SceneManager.LoadScene("MainMenu");
    }

}
