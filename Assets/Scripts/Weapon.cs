using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    private PlayerMovement playerMovement;

    public float chargeTimer = 0;

    private float chargeRate = 2f;
    public float growthRate = .1f;

    private bool buttonHeldDown = false;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
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
        if (Input.GetButtonUp("Fire1") && chargeTimer > 2)
        {
            var cloneBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            cloneBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
            
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
            
            //Scale bullet size
            cloneBullet.transform.localScale += new Vector3(val, val, val);

            //increments bullet damage by 2 after 1 second
            if(chargeTimer > 1)
                cloneBullet.GetComponent<Bullet>().damage += 2;

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
