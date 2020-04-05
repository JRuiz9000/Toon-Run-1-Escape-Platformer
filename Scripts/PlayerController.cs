using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    
    Rigidbody2D rbtd; //private variable
    
    Animator animator;

    AudioSource audioSource;

    public AudioClip clipJump;

    Vector2 force;

    bool facingRight = true;

    bool jumpPending = false;

    public Text livesHead;

    //int numLives = 3;

    //public Text levelHead;

    // Start is called before the first frame update
    void Start()
    {
        rbtd = GetComponent<Rigidbody2D>(); //script starts up , gets attached component, stores reference to that variable
        animator = GetComponent<Animator>(); //get reference to animator
        audioSource = GetComponent<AudioSource>(); 

        livesHead.text = "Lives: " + LiveCounter.numLives.ToString();

    }

    // Update is called once per frame
    void Update()
    {
       
        force = Vector2.zero; //clears out vector
        
        if (Input.GetKey(KeyCode.A))
        {
            force.x = -10; //when A key is pressed, -10 force is applied
        }
        else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10; //when D key is pressed, 10 force is applied 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x, transform.position.y - 1.25f);
            Vector2 dimensions = new Vector2(1.0f, 0.2f);
            
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);
            
            if (grounded)
            {
                jumpPending = true;
                audioSource.clip = clipJump;
                audioSource.Play();
            }            
        }

        if (force.x < 0)
        {
            animator.SetBool("isWalking", true);

            if (facingRight) Flip();
        }
        else if (force.x > 0)
        {
            animator.SetBool("isWalking", true);

            if (facingRight == false) Flip();
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    //Any change to physics or applying force is done here not on Update()
    private void FixedUpdate()
    {
        if (jumpPending)
        {
            force.y = 350;
            jumpPending = false;
        }

        rbtd.AddForce(force);
        //Debug.Log(rb.velocity.x);
        rbtd.velocity = new Vector2(Mathf.Clamp(rbtd.velocity.x, -5, 5), rbtd.velocity.y);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pit" || collision.gameObject.tag == "enemy" )
        {
            LiveCounter.numLives--;
            livesHead.text = "Lives: " + LiveCounter.numLives.ToString();

            if (LiveCounter.numLives <= 0)
            {
                
                SceneManager.LoadScene("GameOverScene");
             
            }
        }
    }
}
