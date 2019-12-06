using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Health/Damage
    public int health = 10;
    public int meleeDamage = 5;
 
    //Movement
    private GameObject player;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioPlayer;
    public AudioClip chomp;
    public AudioClip death;
    public float jumpForce;
    private bool movingRight;
    public bool isOnGround = false;
    public float distance;
    public float speed;
    public Transform groundDetection;
    private GameObject Ground;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Ground = GameObject.FindGameObjectWithTag("Ground");
        _audioPlayer = gameObject.AddComponent<AudioSource>();
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    void Update()
    {
            Patrol();
            Jump();
    }

    void Jump()
    {
        if (isOnGround)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health > 0)
        {
            _audioPlayer.PlayOneShot(chomp, 0.5f);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Patrol()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }

        if (collision.collider.gameObject == player)
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().Take_Damage(meleeDamage);
        }
    }

    void OnCollisionExit2D()
    {
        isOnGround = false;
    }
}
