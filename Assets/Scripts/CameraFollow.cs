using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mario").transform;      
    }


    //runs every frame like update(), but it runs after each item is proccessed in update()
    void LateUpdate() {

        Vector3 tempVar = transform.position;
        tempVar.x = player.position.x;
        transform.position = tempVar;
    
    
    }









}
