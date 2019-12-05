using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportPlayer : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == player.tag)
        {
            player.GetComponent<PlayerHealth>().CurrentHealth += 30;
            Destroy(gameObject);
        }
    }
}
