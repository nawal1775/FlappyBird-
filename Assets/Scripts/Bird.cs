using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class keeps control of the bird movement, it determines when the bird dies and when to win.
/// </summary>
public class Bird : MonoBehaviour
{
    // to check if the player is dead or not before playing 
    private bool isDead = false;

    public Rigidbody2D rb2d;
    public float upForce = 200f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
       if (isDead == false)
        {
            if (Input.GetKeyDown("space"))
            {
                // the rigid body will be falling or raising
                //reset the velocity to zero after a jump 
                rb2d.velocity = Vector2.zero;
                //the player movement, the two number are for x and y to fore the player movement 
                rb2d.AddForce(new Vector2(0, upForce));

                //playing animation
                anim.SetTrigger("Flap");
            }
        }
        if (GameController.inst.youWin == true)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            
            //load the main menu once the player wins
            //SceneManager.LoadScene("MainMenu");

        }
    }
    // check if the bird hits the ground or the pipes, once it does it cannot move, its dead 
    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        // to transition to the die state 
        anim.SetTrigger("Die");

        //call the game controller class and check if the game inst which is bird is dead 
        GameController.inst.BirdDied();

    }
}
