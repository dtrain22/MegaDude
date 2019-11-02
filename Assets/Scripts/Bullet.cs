using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    public int enemyDamage = 5;
    public int playerDamage = 15;
    public Rigidbody2D rb;
    public GameObject owner;
    public GameObject Enemy;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");

        if(Enemy != null && owner != null && owner.tag == "Enemy")
        {
            if (Enemy.GetComponent<Enemy>().isFacingRight)
            {
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = transform.right * speed *-1;
            }
        }
        else
        {
            rb.velocity = transform.right * speed;
        }

       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (owner != null && owner.tag == collision.collider.tag)
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
