using System.Collections;
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
    private const string lavaland = "LavaLevel";
    private float xPos;
    private float yPos;
    private float playerY;
    private float playerX;

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
            playerY = player.transform.position.y + yDist;
            playerX = player.transform.position.x + xDist;

            if (SceneManager.GetActiveScene().name == grassland)
            {
                if (player.transform.position.x < 54 && player.transform.position.y > -10)
                {
                    yPos = (playerY > 5) ? 5 : playerY;
                    xPos = (playerX < -3.49f) ? -3.49f : playerX;       
                    //Debug.Log("Region 1 ->  y: " + yPos + " x: " + xPos);
                }
                else if (player.transform.position.x > 38 && player.transform.position.y < -62)
                {
                    yPos = (playerY > -67) ? -67 : playerY;
                    xPos = (playerX < 40 ) ? 40 : playerX;
                    //Debug.Log("Region 2 ->  y: " + yPos + " x: " + xPos);
                }
                else if ( (player.transform.position.x > 80 && player.transform.position.x < 170) && player.transform.position.y > -32)
                {
                    yPos = (playerY < -23) ? playerY : -22;
                    xPos = (playerX < 80) ? 80 : playerX;
                    //Debug.Log("Region 3 ->  y: " + yPos + " x: " + xPos);
                }
                else if ( player.transform.position.x > 170 && player.transform.position.x < 318)
                {
                    Debug.Log("Inspect ->>>>   playerY: " +playerY + " playerX: " + playerX);
                    if (playerY > 4)
                        yPos = -25;
                    else if (player.transform.position.x > 311)
                        yPos = -33;
                    else
                        yPos = player.transform.position.y + .2f;           

                    xPos = (playerX > 384) ? 384 : playerX;
                }
                else if ( player.transform.position.x > 318)
                {
                    Debug.Log("Last Region ->  y: " + yPos + " x: " + xPos);
                    yPos = -33;
                    xPos = (playerX > 384) ? 384 : playerX;
                }
                else 
                {
                    Debug.Log("Else Region");
                    xPos = player.transform.position.x + xDist;
                    yPos = player.transform.position.y + yDist;
                }
                offset.Set(xPos, yPos, zPos);
                transform.position = offset;

            }
            else if(SceneManager.GetActiveScene().name == lavaland)
            {
                float yPos = player.transform.position.y + yDist;
                float xPos = player.transform.position.x + xDist;
                offset.Set(xPos, yPos, zPos);
                transform.position = offset;
            }
        }
    }

}
