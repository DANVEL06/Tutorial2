﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text= "";
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetScoreValue ();
        }
    

    }
    void SetScoreValue()
    {
        score.text = "" + scoreValue.ToString ();
       if (scoreValue >= 4) 
       {
           winText.text = "You Win! Game created by Daniel Velasco";
       }
    }
    private void OnCollisionStay2D(Collision2D collision)
     {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
            if (Input.GetKey("escape"))
            {
                 Application.Quit();
             }
        }
     }
        
     

}