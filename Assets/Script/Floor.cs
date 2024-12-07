using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public float speed = 5;
    private Vector3 destroy = new Vector2(-20f, -20f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= destroy.x || transform.position.y <= destroy.y )
        {
            Destroy(gameObject);
        }
    }


}
