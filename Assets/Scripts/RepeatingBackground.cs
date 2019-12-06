using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class keeps track of the background and when to reposition it.
/// </summary>
public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundHorizLen;

    // Start is called before the first frame update
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizLen = groundCollider.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        //check if it is time to reposition(when the object is off view)
        if(transform.position.x < -groundHorizLen)
        {
            RepositionBackground();
        }
    }

    //function to reposition the background when it is time to move that
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHorizLen * 2f, 0);
        //this calculates how far the ground has to move and then move it 
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
