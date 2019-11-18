using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public bool goingDown = false;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown)
        {
            float newY = transform.position.y - .03f;
            move.Set(transform.position.x, newY, transform.position.z);
            if (newY < minHeight)
                goingDown = false;
        }

        else
        {
            float newY = transform.position.y + .05f;
            move.Set(transform.position.x, newY, transform.position.z);
            if (newY > maxHeight)
                goingDown = true;
        }
        transform.position = move;
    }
}
