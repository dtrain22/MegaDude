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
    private bool movingRight;
    public bool isOnGround = false;
    public bool isFacingRight;
    public float jumpForce;
    public float distance;
    public float speed;
    public Transform groundDetection;
    private GameObject Ground;

    //Shooting
    private float timeBetweenShots;
    public GameObject projectile;
    public GameObject firePoint;
    public float startTimeBetweenShots;
    public bool isShootingType = false;

    //Sound
    private AudioPlayerWrapper _audioPlayer;
    public AudioClip chomp;
    public AudioClip death;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Ground = GameObject.FindGameObjectWithTag("Ground");
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        isFacingRight = true;
       
    }

    void Update()
    {
        if (isShootingType)
        {
            ChangeDirection();
            FireProjectile();
        }

        if (!isShootingType)
        {
            Patrol();
            Jump();
        }
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
            _audioPlayer.PlaySound(chomp, 0.5f);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void FlipCharacter()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight; 
        transform.Rotate(0f, 180f, 0f);
    }

    private void ChangeDirection()
    {
        if (gameObject != null && player != null)
        {
            if (player.transform.position.x < transform.position.x && isFacingRight)
            {
                    FlipCharacter();
            }
            else if (player.transform.position.x > transform.position.x && !isFacingRight)
            {
                    FlipCharacter();  
            }
        }
    }

    private void FireProjectile()
    {
        if (timeBetweenShots <= 0)
        {
            var projectileClone = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;

            projectileClone.GetComponent<Renderer>().material.color = Color.red;
            projectile.GetComponent<Bullet>().owner = gameObject;

            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
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
