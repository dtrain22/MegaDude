using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public int health = 10;
    public int meleeDamage = 5;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private AudioPlayerWrapper _audioPlayer;
    public AudioClip chomp;
    public AudioClip death;

    void Start()
    {
        player = GameObject.Find("Player");
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
    }

    void Update()
    {
       
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


}
