using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float xspd = 6;
    public float yspd = 5;
    private Rigidbody2D body;
    public Transform groundCheck;
    public Animator anim;

    public float groundCheckRadius;

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
        transform.Translate(Vector2.left * xspd * Time.deltaTime);

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (onGround)
        {
            anim.SetBool("Ground", true);
            body.velocity = new Vector2(body.velocity.x, yspd);
        }
        else
        {
            anim.SetBool("Ground", false);
        }
    }
}
