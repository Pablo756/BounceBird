using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;					
	private bool isCollision = false;			

	private Animator anim;					
	private Rigidbody2D rb2;
  
    void Start()
	{
		anim = GetComponent<Animator> ();
		rb2 = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
        if (isCollision == false) 
		{
			if (Input.GetMouseButtonDown(0)) 
			{
				anim.SetTrigger("Flap");
				rb2.velocity = Vector2.zero;
				rb2.AddForce(new Vector2(0, upForce));
			}
		}
        else 
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Flap_block_bird");
                rb2.velocity = Vector2.zero;
                rb2.AddForce(new Vector2(0, upForce));
            }
        }
	}

    private void FixedUpdate()
    {
        if (GameObject.Find("Bird").transform.position.x < -4)
        {
            Debug.Log("GameOver");
            GameControl.instance.GameOver();
        }
    }

   


    void OnCollisionEnter2D(Collision2D other)
	{
        
        if (other.gameObject.name == "Ground")
        {
            Debug.Log("Ground");
            GameControl.instance.Scored();
        }

        if (isCollision == false)
        {
            isCollision = true;
            anim.SetTrigger("Collision");
        }
        else
        {
            isCollision = false;
            anim.SetTrigger("Non_Collision");
        }	
	}
}
