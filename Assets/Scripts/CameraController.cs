using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float zPos;
    private float xDist;
    private float yDist;
    private Vector3 offset;


    // Start is called before the first frame update

    void Start()
    {
        offset = transform.position - player.transform.position;
        xDist = offset.x;
        yDist = offset.y;
        zPos = offset.z;
    }
    void LateUpdate()
    {
        if (player != null)
        {
            float yPos = player.transform.position.y + yDist;
            float xPos = player.transform.position.x + xDist;
            offset.Set(xPos, yPos, zPos);
            transform.position = offset;
        }
    }
}
