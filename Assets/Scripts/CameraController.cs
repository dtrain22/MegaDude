﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private float zPos;
    private float xDist;
    private float yDist;
    private Vector3 offset;
    private Vector3 position;
    private const string grassland= "First Level Design";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        position = new Vector3(player.transform.position.x + .1f, transform.position.y, transform.position.z);
        transform.position = position;
  
        offset = transform.position - player.transform.position;
        xDist = offset.x;
        yDist = offset.y;
        zPos = offset.z;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            if(SceneManager.GetActiveScene().name == grassland)
            {
                //Camera needs to be tweaked 
                if(player.transform.position.x < 42)
                {
                    float xPos = player.transform.position.x + xDist;
                    offset.Set(xPos, yDist, zPos);
                    transform.position = offset;
                }
                else 
                {
                    float xPos = player.transform.position.x + xDist;
                    float yPos = player.transform.position.y + yDist;
                    offset.Set(xPos, yPos, zPos);
                    transform.position = offset;
                }
            }
 

        }
    }

}
