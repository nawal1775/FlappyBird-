using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// This class keeps track of the game overall in which it activates the game scene, it records the score, enable game over when the bird dies and compare the socre to the high score.
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController inst;
    public GameObject gameOverText;
    public bool gameOver = false;
    public Text scoreText;
    public float scrollSpeed = -1.5f;
    private int score = 0;

    private int highScore = 50;
    public GameObject youWinText;
    public bool youWin = false;

    
    void Awake()
    {
        //if we dont have a game control set this to be it or destroy it 
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //reload the scene when the game is over and the user presses space 
        //if (gameOver == true && Input.GetKeyDown("space"))
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // to check when the bird dies 
    public void BirdDied()
    {
        //display game over text 
        gameOverText.SetActive(true);
        gameOver = true;
    }

    //keep track of the score earned 
    public void PlayerScore()
    {
        // no score if the game is over
        if (gameOver)
        {
            return;
        }
        //else add one the score 
        score++;
        //display the score 
        scoreText.text = "Score: " + score.ToString();

        if (score == highScore)
        {
            youWinText.SetActive(true);
            youWin = true;   
        }
      
    }
}
