using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    GameObject player;
    public int health;
    public bool hasDied; 
    public int CurrentHealth;
    public bool Damage;
    public Slider HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        CurrentHealth = health;
        HealthBar.value = health;
        player = GameObject.FindGameObjectWithTag("Player");
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = CurrentHealth;

        if (player.transform.position.y < -4)
        {
            hasDied = true;
            HealthBar.value = 0;
        }
        if (hasDied)
        {
            StartCoroutine("Die"); 
        }
    }

    IEnumerator Die()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;
    }
    public void Take_Damage(int amount)
    {
        Damage = true;
        CurrentHealth -= amount;
        HealthBar.value = CurrentHealth;
        /*if (CurrentHealth <= 0 && !Dead)
        {
            Death();
        }*/

    }
    /*public void Death()
    {
        Dead = true;
        //Audio_Clip.PlaySound();
        bullets.DisableEffects();
        playerMovement.enabled = false;
        bullets.enabled = false;


    }*/
}

