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
    public PlayerMove Player;
    public int FallDeath;
    public string Scene;

    void Start()
    {
        health = 100;
        CurrentHealth = health;
        HealthBar.value = health;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    void Update()
    {
        HealthBar.value = CurrentHealth;
        if (InvincibilityCounter > 0)
        {
            InvincibilityCounter -= Time.deltaTime;
        }

        if (gameObject.transform.position.y < FallDeath)

        {
            HealthBar.value = 0;
            Die();
        }
    }

    public void Take_Damage(int amount)
    {
        if (InvincibilityCounter <= 0)
        {
            CurrentHealth -= amount;
            HealthBar.value = CurrentHealth;
            InvincibilityCounter = InvincibilityLength;
            //StartCoroutine(Player.Knockback(0.02f, 60, Player.transform.position));
        }
        
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Die();
        }
    }
  
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

