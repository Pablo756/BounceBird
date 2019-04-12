using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			
	public Text scoreText;						
	public GameObject GameOverUI;
    public GameObject Score;
    public bool game_over = false;
    public bool isCollision = false;
    public float upForce;
    public float scrollSpeed = -2f;

    private int score = 0;

    void Awake()
	{
		
		if (instance == null)
			
			instance = this;
		
		else if(instance != this)
			
			Destroy (gameObject);
	}

    public void Scored()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Score.SetActive(false);
        game_over = true;
    }  
}
