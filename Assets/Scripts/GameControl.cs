using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			
	public Text scoreText;						
	public GameObject GameOverUI;

    private int score = 0;						
				
	public float scrollSpeed = -2f;


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
    }
}
