using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    private PlayerMovement playerMovement; // for bullet direction
    private AudioPlayerWrapper _audioPlayer;
    public AudioClip pewpew;
    public AudioClip bigPew;

    public float chargeTimer = 0;
    private float chargeRate = 2f;
    public float growthRate = .1f;
    private bool buttonHeldDown = false;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
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
            var cloneBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            cloneBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;

            float scaleVal;
            int addedDamage = 0;

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
            cloneBullet.GetComponent<Bullet>().damage += addedDamage;
            ButtonReleased();
        } 
    }

    public void HoldButton()
    {
        buttonHeldDown = true;
    }

    public void ButtonReleased()
    {
        buttonHeldDown = false;
        chargeTimer = 0;
        growthRate = 0;
    } 
}
