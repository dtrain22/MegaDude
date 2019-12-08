using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public bool goingDown;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        goingDown = false;
        if(SceneManager.GetActiveScene().name == "First Level Design")
        {
            minHeight = -38;
            maxHeight = -32.5f;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > maxHeight)
            goingDown = true;
        else if (transform.localPosition.y < minHeight)
            goingDown = false;

        if (goingDown)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - .03f, transform.localPosition.z);
        else
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + .05f, transform.localPosition.z);
    }
}
