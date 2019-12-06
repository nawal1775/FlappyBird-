using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class takes care of the pipes and when to randomly generate new ones as well as changing their order.
/// </summary>
public class ColumnPool : MonoBehaviour
{
    private GameObject[] columns;
    public GameObject columsPrefabs;
    //position off the screen 
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    //instantiate 5 columns
    public int columnSize = 5;
    private float timeSinceLastSpawned;

    //we make it public so we can change it later in unity if we needed to 
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    //positioned 10 units to the right off the camera
    private float spawnXPosition = 10f;
    private int currColumn = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;
        // creaing a new array with 5 empty spots 
        columns = new GameObject[columnSize];
        //fill them with new prefabs objects
        for (int i = 0; i < columnSize; i++)
        {
            //instantiating a game object, casting it into an array for each spot in the array 
            columns[i] = (GameObject)Instantiate(columsPrefabs, objectPoolPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //timer 
        timeSinceLastSpawned += Time.deltaTime;
        //check if its time to add a new column
        if (GameController.inst.gameOver == false && GameController.inst.youWin == false && timeSinceLastSpawned >= spawnRate)
        {
            //genrate a random position on y and add the column
            timeSinceLastSpawned = 0f;
            //generate a random number and store it in spawn y position 
            float spawnYPosition = Random.Range(columnMin, columnMax);

            //position our column then add one 
            columns[currColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currColumn++;
            // position it to zero again once we hit 5 
            if(currColumn >= columnSize)
            {
                currColumn = 0;
            }


        }

    }
}
