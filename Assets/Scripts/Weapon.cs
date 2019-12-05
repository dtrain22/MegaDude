﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bullet;
    private PlayerMove playerMovement;

    //Audio
    private AudioSource _oneshotPlayer;
    public AudioClip pewpew;
    public AudioClip bigPew;
    private AudioSource _chargeWeaponPlayer;
    public AudioClip chargeWeapon;

    public float chargeTimer = 0;
    private float chargeRate = 2f;
    public float growthRate = .1f;
    public bool isShooting = false;

    void Start()
    {
        playerMovement = GetComponent<PlayerMove>();
        _chargeWeaponPlayer = gameObject.AddComponent<AudioSource>();
        _chargeWeaponPlayer.clip = chargeWeapon;
        _oneshotPlayer = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (isShooting) {
            chargeTimer += Time.deltaTime * chargeRate;
            growthRate += .01f * .2f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            HoldButton();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            var cloneBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;

            float scaleVal;
            int addedDamage = 0;
            _chargeWeaponPlayer.Stop();

            animator.SetBool("IsShooting", false);    

            if (chargeTimer < 2)
            {
                scaleVal = growthRate; // scale bullet size
                if (chargeTimer > 1)
                    addedDamage += 2;

                _oneshotPlayer.PlayOneShot(pewpew);
                //animator.SetBool("IsShooting", true);
            }
            else
            {
                // max bullet size and damage
                scaleVal = .26f;
                addedDamage = 5;
                cloneBullet.GetComponent<Renderer>().material.color = Color.green;
                _oneshotPlayer.PlayOneShot(bigPew);
                //animator.SetBool("IsShooting", true);
            }
          
            cloneBullet.transform.localScale += new Vector3(scaleVal, scaleVal, scaleVal);
            cloneBullet.GetComponent<Bullet>().enemyDamage += addedDamage;
            cloneBullet.GetComponent<Bullet>().owner = gameObject;
            ButtonReleased();
            //animator.SetBool("IsShooting", false);
        }
    }

    public void HoldButton()
    {
        isShooting = true;
        // play slightly delayed so player doesn't hear it when bullet spamming
        _chargeWeaponPlayer.PlayDelayed(0.08f);
    }

    public void ButtonReleased()
    {
        isShooting = false;
        chargeTimer = 0;
        growthRate = 0;
    } 
}
