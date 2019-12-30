using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 pos;
    public float jump = 5;
    private Rigidbody2D body;
    public Transform groundCheck;

    public float groundCheckRadius;

    public LayerMask whatIsGround;

    private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        // Takes info from the Ground Check object to determine if player is touching ground before jumping
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            body.velocity = new Vector2(body.velocity.x, jump * Time.deltaTime);
            // Won't jump
        }
    }
}
