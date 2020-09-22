using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{


    float startPos;
    float endPos;
    float moveVertical;
    Vector2 movement;
    bool isUP;

    [SerializeField]
    int movingDistance;

    [SerializeField]
    float speed;

    Transform transform;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        speed = 2.5f;
        isUP = true;
        movingDistance = 3 ;
        startPos = transform.position.y;
        endPos = transform.position.y + movingDistance;
        //moveVertical = Input.GetAxis("Vertical");
        //movement = new Vector2(0, moveVertical);
       // rb.AddForce(moveVertical * speed);

    }

    // Update is called once per frame
    void Update()
    {
        tile_move_up_down();


    }

    void tile_move_up_down() {

        //rb.AddForce(movement * speed);
        if (isUP)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (!isUP)
        {
            rb.velocity = new Vector2(0, -speed);
        }

        if (transform.position.y >= endPos)
        {
            isUP = false;
        }
        else if (transform.position.y <= startPos)
        {
            isUP = true;
        }


    }

}


