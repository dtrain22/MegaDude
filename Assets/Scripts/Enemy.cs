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

    public float distance;
    public float speed;

    private bool movingRight;

    public Transform groundDetection;

    void Start()
    {
        player = GameObject.Find("Player");
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

       RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
       if(groundInfo.collider == false){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

       }

    }

    public void Damage(int dmg)
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
