using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip footStep, chargeShoot, deathSound, ememyDeathSound, jumpSound;
    static AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        footStep = Resources.Load<AudioClip>("foot");
        chargeShoot = Resources.Load<AudioClip>("shoot");
        deathSound = Resources.Load<AudioClip>("death");
        ememyDeathSound = Resources.Load<AudioClip>("enemyDeath");
        jumpSound = Resources.Load<AudioClip>("jump");

        audioScr = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "foot":
                audioScr.PlayOneShot(footStep);
                break;
        
            case "shoot":
                audioScr.PlayOneShot(chargeShoot);
                break;
        
            case "death":
                audioScr.PlayOneShot(deathSound);
                break;
       
            case "enemyDeath":
                audioScr.PlayOneShot(ememyDeathSound);
                break;
        
            case "jump":
                audioScr.PlayOneShot(jumpSound);
                break;
        }
    }
}
