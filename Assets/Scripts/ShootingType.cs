using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingType : MonoBehaviour
{
    private GameObject player;
    private float timeBetweenShots;
    private GameObject projectile;
    private GameObject firePoint;
    private float startTimeBetweenShots;
    public bool isFacingRight;

    void Start()
    {
        firePoint = transform.GetChild(0).gameObject;
        projectile = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/PreFabs/Bullet.prefab", typeof(GameObject));
        player = GameObject.FindGameObjectWithTag("Player");
        isFacingRight = true;
        startTimeBetweenShots = 1;
    }

    void Update()
    {
        var rangeX = Mathf.Abs(player.transform.position.x - transform.position.x);
        var rangeY = Mathf.Abs(player.transform.position.y - transform.position.y);
 
        if(rangeX < 20 && rangeY < 4)
        {
            ChangeDirection();
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        if (timeBetweenShots <= 0)
        {
            Debug.Log(gameObject.name + " Shooting");
            var projectileClone = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;

            projectileClone.GetComponent<Renderer>().material.color = Color.red;
            projectile.GetComponent<Bullet>().owner = gameObject;

            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    private void ChangeDirection()
    {
        if (player != null)
        {
            if (player.transform.position.x < transform.position.x && isFacingRight)
            {
                FlipCharacter();
            }
            else if (player.transform.position.x > transform.position.x && !isFacingRight)
            {
                FlipCharacter();
            }
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
