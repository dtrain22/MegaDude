using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public int health = 10;
    public int meleeDamage = 5;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    private AudioPlayerWrapper _audioPlayer;
    public AudioClip chomp;
    public AudioClip death;
    public GameObject projectile;
    public bool isFacingRight;
    public GameObject firePoint;

    void Start()
    {
        isFacingRight = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;

    }

    void Update()
    {
        if (gameObject != null && player != null)
        {
            if (player.position.x < transform.position.x)
            {
                if (isFacingRight)
                {
                    Flip();
                }
            }
            else
            {
                if (!isFacingRight)
                {
                    Flip();
                }
            }
        }

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

    public void takeDamage(int dmg)
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

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
