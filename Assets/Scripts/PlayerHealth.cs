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
    public int StartingHealth = 100;
    public int CurrentHealth;
    public Slider HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        StartingHealth = CurrentHealth;
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
        if (CurrentHealth <= 0 && !Dead)
        {
            Death();
        }

    }
    public void Death()
    {
        Dead = true;
        //Audio_Clip.PlaySound();
        bullets.DisableEffects();
        playerMovement.enabled = false;
        bullets.enabled = false;


    }
}

/*
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int StartingHealth = 100;
    public int CurrentHealth;dafdsadsasfgs
    public Slider HealthBar;
    public bool Dead;
    public bool Damage;
    //public AudioPlayerWrapper;

    //AudioPlayerWrapper AudioClip;
    Bullet bullets;
    PlayerMovement playerMovement;
   // MovementFunction movement;

    // Use this for initialization
    void Start()
    {
        //AudioClip = GetComponent<AudioPlayerWrapper>();
        //bullets = GetComponent<Bullet>();
        //playerMovement = GetComponent<PlayerMovement>();
        //movement = GetComponent<MovementFunction>();
        StartingHealth = CurrentHealth;
        //HealthBar.value = CurrentHealth(Take_Damage);
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.value = CurrentHealth;
    }

    public void Take_Damage(int amount)
    {
        Damage = true;
        CurrentHealth -= amount;
        HealthBar.value = CurrentHealth;
        if(CurrentHealth <= 0 && !Dead)
        {
            Death();
        }

    }
    public void Death()
    {
        Dead = true;
        //Audio_Clip.PlaySound();
        bullets.DisableEffects();
        playerMovement.enabled = false;
        bullets.enabled = false;


    }
}



*/
