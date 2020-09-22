using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashroumEnemy : MonoBehaviour
{


    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform transform;

    [SerializeField]
    float speed;

    [SerializeField]
    bool isRight = true;

    //bool atEnd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        transform = GetComponent<Transform>();

        speed = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        enemy();
    }


    void enemy() {

        if (Mathf.Abs(rb.velocity.x) <= 0.01f)
        {
            isRight = !isRight;
            sr.flipX = !sr.flipX;
        }

        if (isRight)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            // rb.velocity = new Vector2(Time.fixedDeltaTime * speed * -1, rb.velocity.y);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

    }







}
