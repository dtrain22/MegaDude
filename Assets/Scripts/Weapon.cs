using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    private PlayerMovement playerMovement; // for bullet direction

    // AudioClip
    public AudioClip pewpew;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var tbullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            tbullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;

            PlayerAudio.PlaySound(pewpew);
        }
    }
}
