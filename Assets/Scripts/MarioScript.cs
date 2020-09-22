using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarioScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform transform;
    Animator anim;

    [SerializeField]
    float speed = 5.0f;

    [SerializeField]
    float jump = 5.0f;

    [SerializeField]
    bool isJump;

    int score;
    int playerHealth;
    int maxPlayerHealth = 5;
    int time;

    public GameObject bulletRight;
    public GameObject bulletLeft;
    Vector2 bulletPos;
    public float fireRate = 0.0f;
    float nextFire = 0f;

    public Transform panelHolder;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI livesTxt;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();

        time = 290;
        score = 0;
        playerHealth = 5;

        timeTxt = panelHolder.Find("timeTxt").GetComponent<TextMeshProUGUI>();
        scoreTxt = panelHolder.Find("scoreTxt").GetComponent<TextMeshProUGUI>();
        livesTxt = panelHolder.Find("livesTxt").GetComponent<TextMeshProUGUI>();

        scoreTxt.text = "score :" + score ;
        livesTxt.text = playerHealth + "/" + maxPlayerHealth;
        timeTxt.text = "Time :" + time;
    }

    //---------------------------------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            if (Input.GetButtonDown("Fire1")) {
           // nextFire = Time.time + fireRate;
            fire();
            time--;
            timeTxt.text = "Time :" + time;
        }


    }


    //---------------------------------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        movePlayer();
    }

    
    void movePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.AddForce( Vector2.right * speed * Input.GetAxis("Horizontal"));
            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
            sr.flipX = true;
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // rb.AddForce(Vector2.right * speed * Input.GetAxis("Horizontal"));
            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
            sr.flipX = false;
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        }
        else if (Input.GetButtonDown("Jump") && !isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);               //for jumping 
            isJump = true;
            anim.SetFloat("Jump_hight", Mathf.Abs(transform.position.y));
        }
        else {
            anim.SetFloat("Speed", 0);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isJump = false;
            anim.SetFloat("Jump_hight", Mathf.Abs(transform.position.y));
            anim.SetBool("IsHit", false);
        }
    }



    void fire() {

        bulletPos = transform.position;
        if (!sr.flipX)
        {
            bulletPos += new Vector2(+1f, -0.5f);
            Instantiate(bulletRight, bulletPos, Quaternion.identity);
        }
        else if(sr.flipX) {
            bulletPos += new Vector2(-1f, 0.5f);
            Instantiate(bulletLeft, bulletPos, Quaternion.identity);
        }
        
    
    }



    void OnTriggerEnter2D(Collider2D collider){         //detecting collision with object has no rigidbody
        if (collider.CompareTag("coin"))
        {                                            //can be [ collider.tag == "enemy" ] but method has better performance
            score += 1;                             //scoreText.text = "Score: " + score;
            scoreTxt.text = "score :" + score;
            Destroy(collider.gameObject);

        }
        else if (collider.CompareTag("coin2"))
        {
            score += 2;
            scoreTxt.text = "score :" + score;
            Destroy(collider.gameObject);

        }
        else if (collider.CompareTag("coin3"))
        {
            score += 5;
            scoreTxt.text = "score :" + score;
            Destroy(collider.gameObject);
        }
        else if (collider.CompareTag("brick_red"))
        {
            anim.SetBool("Brick_hit", true);
        }
        else if (collider.CompareTag("brick_question")) {
            anim.SetBool("Question_hit", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collider){        //detecting collision with objects has rigidbody
        if (collider.gameObject.CompareTag("mashroum_enemy"))
        {           
            if (isJump && rb.velocity.y < 0)
            {
                Destroy(collider.gameObject);
            }
            else
            {
                if (playerHealth > 0)
                {
                    playerHealth--;
                    livesTxt.text = playerHealth + "/" + maxPlayerHealth;
                    anim.SetBool("IsHit", true);
                }
                else {
                    Destroy(collider.gameObject);
                }  
            }

        }

       

    }
















    }