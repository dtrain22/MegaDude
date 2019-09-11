using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;

    // AudioClip
    public AudioClip chomp;

    public void Start()
    {

    }

    public void Damage(int dmg)
    {
        health -= dmg;
        PlayerAudio.PlaySound(chomp, 0.5f);
        if (health <= 0)
            Destroy(gameObject);
    }
}
