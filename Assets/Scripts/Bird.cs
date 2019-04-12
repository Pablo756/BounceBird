using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	private Animator anim;					
	private Rigidbody2D rb2;
    private IEnumerator coroutine;

    void Start()
	{
		anim = GetComponent<Animator> ();
		rb2 = GetComponent<Rigidbody2D>();
        
    }

	void Update()
	{  
        if (Input.GetMouseButtonDown(0))
        {
            if (GameControl.instance.isCollision == false)
            {
                GameControl.instance.isCollision = true;
            }
            else
            {
                GameControl.instance.isCollision = false;
            }
            if (GameControl.instance.isCollision == false)
            {
                anim.SetTrigger("Non_Collision");
                anim.SetTrigger("Flap");
                rb2.velocity = Vector2.zero;
                rb2.AddForce(new Vector2(0, GameControl.instance.upForce));
            }
            else
            {
                anim.SetTrigger("Collision");
                anim.SetTrigger("Flap_block_bird");
                rb2.velocity = Vector2.zero;
                rb2.AddForce(new Vector2(0, GameControl.instance.upForce));
            }
        }
    }


 

   

    void OnCollisionEnter2D(Collision2D other)
	{
        GameControl.instance.GameOver();     	
	}

    void OnTriggerExit2D(Collider2D other)
    {        
        GameControl.instance.Scored();        
    }

}
