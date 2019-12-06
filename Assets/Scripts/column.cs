using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class checks when the bird goes through the pipes.
/// </summary>
public class column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check  whatever goes through the trigger to see if it has a bird
        if(other.GetComponent<Bird>() != null)
        {
            //call the game controller class /player score 
            GameController.inst.PlayerScore();
        }
    }
}
