using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private AudioPlayerWrapper _audioPlayer;
    public AudioClip pewpew;
    public AudioClip bigPew;
    public AudioClip chargeWeapon;

    public float chargeTimer = 0;
    private float chargeRate = 2f;
    public float growthRate = .1f;
    private bool buttonHeldDown = false;

    void Start()
    {
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
        _audioPlayer._audioSource.clip = chargeWeapon;
    }

    void Update()
    {
  
        if (buttonHeldDown) {
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
            _audioPlayer._audioSource.Stop();

            if (chargeTimer < 2)
            {
                scaleVal = growthRate; // scale bullet size
                if (chargeTimer > 1)
                    addedDamage += 2;

                _audioPlayer.PlaySound(pewpew);
            }
            else
            {
                // max bullet size and damage
                scaleVal = .26f;
                addedDamage = 5;
                cloneBullet.GetComponent<Renderer>().material.color = Color.green;
                _audioPlayer.PlaySound(bigPew);
            }

            cloneBullet.transform.localScale += new Vector3(scaleVal, scaleVal, scaleVal);
            cloneBullet.GetComponent<Bullet>().enemyDamage += addedDamage;
            cloneBullet.GetComponent<Bullet>().owner = gameObject;
            ButtonReleased();
        } 
    }

    public void HoldButton()
    {
        buttonHeldDown = true;
        _audioPlayer._audioSource.PlayDelayed(0.08f);
    }

    public void ButtonReleased()
    {
        buttonHeldDown = false;
        chargeTimer = 0;
        growthRate = 0;
    } 
}
