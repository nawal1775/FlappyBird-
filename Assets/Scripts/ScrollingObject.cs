using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class keeps track of the scrolling objects and when to stop its movement as well as reloaing the main menu. 
/// </summary>
public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D rb2d;
    // 3 seconds to reload the main menu 
    float timeToLoadScene = 3;
    bool timerEnabled;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // y is zero because we dont want it to scroll up and down as it does 
        rb2d.velocity = new Vector2(GameController.inst.scrollSpeed, 0);
    }

    // Update is called once per frame
    //stop scrolling when the game is over 
    void Update()
    {
        //stop any and all objects when the game is over 
        if (GameController.inst.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
      
        }
        if (GameController.inst.youWin == true)
        {
            rb2d.velocity = Vector2.zero;

            // after 3 seconds, load the main menu when the player wins 

            Invoke("GoToScene", timeToLoadScene);

        }
        
    }
    // function to add a timer to load the main menu when the player wins 
    void GoToScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    
}
