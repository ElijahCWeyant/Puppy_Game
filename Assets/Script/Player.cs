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
    private bool jumping = false;

    public LayerMask whatIsGround;

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
            
            StartCoroutine(wait());
        }
        else if (jumping && onGround)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", !onGround);
        }

    }

    private void OnTriggerEnter2D(Collider2D fall)
    {
        if (fall.CompareTag("Bottom"))
        {
            health = 0;
        }
    }
    public IEnumerator wait()
    {
        jumping = true;
        anim.SetBool("Jump", true);
        yield return new WaitForSeconds(0.2f);
        body.velocity = new Vector2(body.velocity.x, jump);
        jumping = false;
    }


}
