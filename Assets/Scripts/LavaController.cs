using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private GameObject player;
    public float currentHeight;
    public float maxHeight;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHeight = transform.position.y;
        maxHeight = 36;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHeight < maxHeight && player.transform.position.x > 197)
        {
            float newY = transform.position.y + .02f;
            move.Set(transform.position.x, newY, transform.position.z);
            transform.position = move;
            currentHeight = newY;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().Die();
        }
    }
}
