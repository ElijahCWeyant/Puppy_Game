using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float xspd = 6;
    public float yspd = 5;
    private Rigidbody2D body;
    public Transform groundCheck1;
    public Animator anim;
    public int damage = 1;
    public float groundCheckRadius;

    public LayerMask whatIsGround1;

    private bool onGround;
    private Vector3 destroy = new Vector2(-15f, -15f);
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * xspd * Time.deltaTime);

        onGround = Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, whatIsGround1);
        if (onGround)
        {
            anim.SetBool("Ground", true);
            StartCoroutine(jump());
        }
        else
        {
            anim.SetBool("Ground", false);
        }

        if (transform.position.x <= destroy.x || transform.position.y <= destroy.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }

    public IEnumerator jump()
    {
        yield return new WaitForSeconds(0.3f);
        body.velocity = new Vector2(body.velocity.x, yspd);
    }
}
