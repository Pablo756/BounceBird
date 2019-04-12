using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingWall : MonoBehaviour
{
    private Rigidbody2D rb2;

    // Use this for initialization
    void Start()
    {        
        rb2 = GetComponent<Rigidbody2D>();        
        rb2.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    void Update()
    {
        if (GameControl.instance.game_over == true)
        {
            rb2.velocity = Vector2.zero;
        }
    }


    

}