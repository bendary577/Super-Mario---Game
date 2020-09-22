using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletScript : MonoBehaviour
{

    public GameObject bullet_emitter;
    public GameObject bullet;
    public float bullet_force;

    // Start is called before the first frame update
    void Start()
    {
        bullet_force = 1000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    void fire() {

        if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))) {

            GameObject temp_bullet_handler;
            temp_bullet_handler = Instantiate(bullet, bullet_emitter.transform.position, bullet_emitter.transform.rotation) as GameObject;

            temp_bullet_handler.transform.Rotate(Vector3.left);

            Rigidbody2D temp_rigidbody;
            temp_rigidbody = temp_bullet_handler.GetComponent<Rigidbody2D>();

            temp_rigidbody.AddForce(transform.forward * bullet_force);
            //temp_rigidbody.AddForce(1000, 0, 0);
           // temp_rigidbody.velocity = transform.TransformDirection(Vector3.forward * bullet_force);

              Destroy(temp_bullet_handler, 10.0f);

        }
    
    }




}
