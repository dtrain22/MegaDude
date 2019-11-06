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
    public GameObject Player;

    void Start()
    {
        Enemy = GameObject.Find("Shooting_Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Enemy != null && owner != null && owner.tag == "Enemy")
        {
            if (Enemy.GetComponent<Enemy>().isFacingRight)
            {
                rb.velocity = transform.right * speed;
            }
            else if (!Enemy.GetComponent<Enemy>().isFacingRight)
            {
                rb.velocity = transform.right * speed * -1;
            }
        }
<<<<<<< HEAD
        else
            rb.velocity = transform.right * speed;
=======
>>>>>>> 1579dd6523677166f508db249cc8cdc1fe7fd4f1
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (owner != null && owner.gameObject == collision.collider.gameObject)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
<<<<<<< HEAD
            if (collision.collider.gameObject.tag == "Enemy")
=======
            if (collision.collider.gameObject == Enemy)
>>>>>>> 1579dd6523677166f508db249cc8cdc1fe7fd4f1
            {
                collision.collider.gameObject.GetComponent<Enemy>().TakeDamage(enemyDamage);
            }

            if (collision.collider.gameObject == Player)
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
