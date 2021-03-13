using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public Text lives;
    private int livesValue = 3;
    private int livesValues = 3;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text winText;
    public Text loseText;
    public GameObject player;
    public float jumpForce;
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    Animator anim;
    private bool facingRight = true;
   

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text= "";
        lives.text = livesValue.ToString();
        loseText.text= "";
         anim = GetComponent<Animator>();
         if (Input.GetKey("escape"))
            {
                 Application.Quit();
             }  
        
    }
    void Update()
    {
     if (Input.GetKey("escape"))
            {
                 Application.Quit();
             }  
     if (Input.GetKeyDown(KeyCode.M))
        {
          musicSource.clip = musicClipOne;
          musicSource.Play();

         }
         if (Input.GetKeyDown(KeyCode.W))

        {

          anim.SetInteger("State", 2);

         }

     if (Input.GetKeyUp(KeyCode.W))

        {

       

          anim.SetInteger("State", 0);

         }
          if (Input.GetKeyDown(KeyCode.D))

        {

          anim.SetInteger("State", 1);

         }

     if (Input.GetKeyUp(KeyCode.D))

        {

          anim.SetInteger("State", 0);

         }
         if (Input.GetKeyDown(KeyCode.A))

        {

          anim.SetInteger("State", 1);

         }

     if (Input.GetKeyUp(KeyCode.A))

        {

          anim.SetInteger("State", 0);

         }
         

     

     if (Input.GetKeyDown(KeyCode.L))
        {
          musicSource.loop = true;
         }

     if (Input.GetKeyUp(KeyCode.L))
        {
          musicSource.loop = false;
        }
       
}
    

    // Update is called once per frame
    
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);
        if (facingRight == false && hozMovement > 0)
        {
             Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
             Flip();
        }
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
        if (collision.collider.tag == "enemy")
        {
            livesValue -= 1;
            lives.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
            SetlivesValue ();
        }
        if (Input.GetKey("escape" ))
            {
                 Application.Quit();
             }  
         
    }
    
        
   
    void Flip()
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }
   
    void SetScoreValue()
    {
        score.text = "" + scoreValue.ToString ();
       if (scoreValue >= 8) 
       {
           winText.text = "YOU WIN!!!! Game created by Daniel Velasco";
           musicSource.Stop();
           musicSource.clip = musicClipTwo;
           musicSource.Play();
       }
       if (scoreValue == 4) 
        {
           
            transform.position = new Vector3(-24.03f, -3.55f, 0.0f); 
            
        } 
        if (Input.GetKey("escape"))
            {
                 Application.Quit();
             }  
    }
     void SetlivesValue()
    {
        lives.text = "Lives:" + livesValue.ToString ();
         
       if (livesValue == 0) 
       {
           loseText.text = "YOU LOSE!!! Game created by Daniel Velasco";
           Destroy(player.gameObject);  
       }  
       if (Input.GetKey("escape"))
            {
                 Application.Quit();
            }       
      

       
    }
    
 
    
    private void OnCollisionStay2D(Collision2D collision)
     {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            }
            
        }
     }
     
 }
 
     

