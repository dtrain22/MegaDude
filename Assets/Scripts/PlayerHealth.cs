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

    void Start()
    {
        health = 100;
        CurrentHealth = health;
        HealthBar.value = health;
    }

    void Update()
    {
        HealthBar.value = CurrentHealth;
        if (InvincibilityCounter > 0)
        {
            InvincibilityCounter -= Time.deltaTime;
        }
        handleFallDeath();
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
            Destroy(gameObject);
            Die();
        }
    }
  
    public void Die()
    {
        HealthBar.value = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void handleFallDeath()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case grassLand:
                if (transform.position.x < 42)
                    FallDeath(-8);
                else if (transform.position.x > 42 || transform.position.x < 133)
                    FallDeath(-92);
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
            Die();
        }
    }
}

