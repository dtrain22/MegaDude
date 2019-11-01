using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    public int enemyDamage = 5;
    public int playerDamage = 10;
    public Transform _transform;
    public Rigidbody2D rb;
    public GameObject owner;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (owner.tag == collision.collider.tag)
        {
            return;
        }
        else
        {
            if (collision.collider.tag == "Enemy")
            {
                collision.collider.gameObject.GetComponent<Enemy>().takeDamage(enemyDamage);
            }

            if (collision.collider.tag == "Player")
            {
                collision.collider.gameObject.GetComponent<PlayerHealth>().Take_Damage(playerDamage);
            }
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
