using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int CurrentHealth;
    public bool Damage;
    public Slider HealthBar;
    public float InvincibilityLength;
    private float InvincibilityCounter;
    private const string grassLand = "First Level Design";
    private const string lavaLand = "LavaLevel";
    private GameObject gameOverTxt, restartTxt, giveUpTxt;

    void Start()
    {
        health = 100;
        CurrentHealth = health;
        HealthBar.value = health;

        gameOverTxt = GameObject.FindGameObjectWithTag("GameOver");
        restartTxt = GameObject.FindGameObjectWithTag("Restart");
        giveUpTxt = GameObject.FindGameObjectWithTag("GiveUp");
        gameOverTxt.SetActive(false);
        restartTxt.SetActive(false);
        giveUpTxt.SetActive(false);
    }

    void Update()
    {
        HealthBar.value = CurrentHealth;
        if (InvincibilityCounter > 0)
        {
            InvincibilityCounter -= Time.deltaTime;
        }

        HandleFallDeath();
        if (CurrentHealth > 100)
        {
            CurrentHealth = 100;
        }
    }

    public void Take_Damage(int amount)
    {
        if (InvincibilityCounter <= 0)
        {
            CurrentHealth -= amount;
            HealthBar.value = CurrentHealth;
            InvincibilityCounter = InvincibilityLength;
        }
        
        if(CurrentHealth <= 0)
        {
            GameOver();
        }
    }
  
    public void Die()
    {
        HealthBar.value = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void HandleFallDeath()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case grassLand:
                if (transform.position.x < 38)
                    FallDeath(-8);
                else if (transform.position.x > 38 || transform.position.x < 133)
                    FallDeath(-85);
                else if (transform.position.x > 212 || transform.position.x < 354)
                    FallDeath(-44);
                break;

            case lavaLand:
                if (transform.position.x < -5)
                    FallDeath(23);
                else if (transform.position.x > 285)
                    FallDeath(-8);
                break;
        }
    }

    void FallDeath(int val)
    {
        if (transform.position.y < val)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverTxt.SetActive(true);
        restartTxt.SetActive(true);
        giveUpTxt.SetActive(true);
        gameObject.SetActive(false);
    }
}

