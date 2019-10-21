using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int CurrentHealth;
    public int meleeDamage = 5;
    public bool Damage;
    public Slider HealthBar;

    /*private Material FlashWhite;
    private Material FlashDefault;
    SpriteRenderer Sr;
    Start is called before the first frame update*/

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

    public void Take_Damage(int amount)
    {
        CurrentHealth -= amount;
        HealthBar.value = CurrentHealth;

        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Enemy")
        {
            Take_Damage(meleeDamage);
        }
    }
}

