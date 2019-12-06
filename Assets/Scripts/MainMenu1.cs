using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class loads the main menu scene where it controls the options play and quit.
/// </summary>
public class MainMenu1 : MonoBehaviour
{
    //to start the game 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("SampleScene");
    }

    //to quit the game
    public void QuitGame()
    {
        // a massege to make sure the programe quit 
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
