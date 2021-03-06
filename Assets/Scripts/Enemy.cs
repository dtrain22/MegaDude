﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private GameObject Ground;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioPlayer;
    private bool isOnGround;
    public int health;
    public int meleeDamage;
    public float jumpForce;
    public float distance;
    public AudioClip chomp;
    public AudioClip death;
    private GameObject loot;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Ground = GameObject.FindGameObjectWithTag("Ground");
        _audioPlayer = gameObject.AddComponent<AudioSource>();
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        loot = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/PreFabs/HealthPack.prefab", typeof(GameObject));

        isOnGround = false;
        health = 20;
        meleeDamage = 5;
    }

    void Update()
    {
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
            var position = transform.position;
            var rotation = Quaternion.identity;
            Destroy(gameObject);
            DropLoot(position, rotation);
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

    void DropLoot(Vector3 position, Quaternion rotation)
    {
        if(Random.Range(1, 1000) < 200)
        {
            Instantiate(loot, position, rotation);
        }
    }
}
