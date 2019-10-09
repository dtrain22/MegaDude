using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    private PlayerMovement playerMovement; // for bullet direction

    private AudioPlayerWrapper _audioPlayer;

    // AudioClip
    public AudioClip pewpew;

    public float chargeTimer = 0;

    private float chargeRate = 2f;
    public float growthRate = .1f;

    private bool buttonHeldDown = false;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        _audioPlayer = GetComponent(typeof(AudioPlayerWrapper)) as AudioPlayerWrapper;
    }

    // Update is called once per frame
    void Update()
    {
  
        if (buttonHeldDown) {
            chargeTimer += Time.deltaTime * chargeRate;
            growthRate += .01f * .2f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            HoldButton();
            //chargeTimer += Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            var cloneBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            cloneBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
            //_audioPlayer.PlaySound(pewpew);
            _audioPlayer.PlaySound(pewpew);

            float scaleVal;
            int addedDamage = 0;
            if (chargeTimer < 2)
            {
                scaleVal = growthRate; // scale bullet size
                // +2 damage if held for over 1 sec
                if (chargeTimer > 1)
                    addedDamage += 2;
            }
            else // chargeTimer >= 2
            {
                // max bullet size and damage
                scaleVal = .26f;
                addedDamage = 5;
                // bullet becomes green
                cloneBullet.GetComponent<Renderer>().material.color = Color.green;
            }

            cloneBullet.transform.localScale += new Vector3(scaleVal, scaleVal, scaleVal);
            cloneBullet.GetComponent<Bullet>().damage += addedDamage;
            ButtonReleased();
        }
        /* old
        if (Input.GetButtonUp("Fire1") && chargeTimer > 2)
        {
            var cloneBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            cloneBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
            _audioPlayer.PlaySound(pewpew);
            //Set max bullet size
            cloneBullet.transform.localScale += new Vector3(.26f, .26f, .26f);
            //Set max bullet power 
            cloneBullet.GetComponent<Bullet>().damage = 10;
            //Change bullet color
            cloneBullet.GetComponent<Renderer>().material.color = Color.green;
            ButtonReleased();
        }
        else if (Input.GetButtonUp("Fire1") && chargeTimer < 2)
        {
            var val = growthRate;

            var cloneBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            cloneBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
            _audioPlayer.PlaySound(pewpew);
            //Scale bullet size
            cloneBullet.transform.localScale += new Vector3(val, val, val);

            //increments bullet damage by 2 after 1 second
            if(chargeTimer > 1)
                cloneBullet.GetComponent<Bullet>().damage += 2;

            ButtonReleased();
         
        }
        */
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
