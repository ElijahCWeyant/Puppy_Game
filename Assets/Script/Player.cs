using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jump = 5;
    private Rigidbody2D body;
    public Transform groundCheck;
    public int health = 3;
    public float groundCheckRadius;
    public Animator anim;
    public LayerMask whatIsGround;

    public float run = 1;
    public float speed = 50;
    public Vector2 RunTo;
    public float MinRight = 0;
    public float RelitivePos = 0;
    public float MaxRight = 15;
    private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        // Takes info from the Ground Check object to determine if player is touching ground before jumping
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            body.velocity = new Vector2(body.velocity.x, jump);
 
        }
        if (Input.GetKeyDown(KeyCode.D) && onGround && RelitivePos < MaxRight)
        {
            RunTo = new Vector2(transform.position.x + run, transform.position.y);
            transform.position = Vector2.MoveTowards(RunTo, transform.position, speed * Time.deltaTime);
            RelitivePos++;
        }
        else if (Input.GetKeyDown(KeyCode.A) && onGround && RelitivePos > MinRight)
        {
            RunTo = new Vector2(transform.position.x - run, transform.position.y);
            transform.position = Vector2.MoveTowards(RunTo, transform.position, speed * Time.deltaTime);
            RelitivePos--;
        }


        /*
        transform.position = Vector2.MoveTowards(RunTo, transform.position, speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.D) && onGround)
        {
            RunTo = new Vector2(transform.position.x + run, transform.position.y);
            
        }
        else if (Input.GetKeyDown(KeyCode.A) && onGround)
        {
            RunTo = new Vector2(transform.position.x - run, transform.position.y);

        }
        */
    }

    private void OnTriggerEnter2D(Collider2D fall)
    {
        if (fall.CompareTag("Bottom"))
        {
            health = 0;
        }
    }



}
