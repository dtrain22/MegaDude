using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    private PlayerMovement playerMovement;
    public float timer = 0;
    private Vector3 position = new Vector3(5,5,0);

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        updateTime();

        if(timer >= 2)
        {
            timer = 0;
            //This is very buggy
            var thisBullet = Instantiate(bullet, position, bullet.transform.rotation) as GameObject;
            thisBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
        }
    }

    void updateTime()
    {
        timer += Time.deltaTime;
    }
}
