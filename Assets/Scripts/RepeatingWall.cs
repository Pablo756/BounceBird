using UnityEngine;
using System.Collections;

public class RepeatingWall : MonoBehaviour
{
    public GameObject wallPrefab;                                 
    public int amountWall = 5;                                
    public float spawnRate = 3f;                                    
    public float columnMin = -1f;                                   
    public float columnMax = 3.5f;                                  

    private GameObject[] walls;                                   
    private int currentWall = 0;                                  

    private Vector2 objectPoolPosition = new Vector2(-15, -25);     
    private float timeLastSpawned;


    void Start()
    {
        timeLastSpawned = 0f;
        walls = new GameObject[amountWall];
        //Loop through the collection... 
        for (int i = 0; i < amountWall; i++)
        {
            walls[i] = (GameObject)Instantiate(wallPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeLastSpawned += Time.deltaTime;

        if (GameControl.instance.game_over == false && timeLastSpawned >= spawnRate)
        {
            timeLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            walls[currentWall].transform.position = new Vector2(10f, spawnYPosition);
            currentWall++;

            if (currentWall >= amountWall)
            {
                currentWall = 0;
            }
        }
    }    
}