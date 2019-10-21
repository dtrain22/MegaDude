using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    GameObject player;
    public int health; 
    public int CurrentHealth;
    public bool Damage;
    public Slider HealthBar;
    /*private Material FlashWhite;
    private Material FlashDefault;
    SpriteRenderer Sr;*/
    // Start is called before the first frame update

    void Start()
    {
        health = 100;
        CurrentHealth = health;
        HealthBar.value = health;
        /*Sr = GetComponent<SpriteRenderer>();
        FlashWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        FlashDefault = Sr.material;*/
    }

    void Update()
    {
        HealthBar.value = CurrentHealth;

        if (gameObject.transform.position.y < -4)

        {
            HealthBar.value = 0;
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Take_Damage(int amount)
    {
  //      if (Damage ==                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    true)
        Damage = true;
        CurrentHealth -= amount;
        HealthBar.value = CurrentHealth;
        //Sr.material = FlashWhite;
       /* else
        {
            Invoke("ResetMaterial", .1f);
        }*/
            
        /*if (CurrentHealth <= 0 && !Dead)
        {
            Death();
        }*/

    }
    /*void ResetMaterial()
    {
        Sr.material = FlashDefault;
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

