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
    public PlayerMovement Player;
    public int FallDeath;
    public string Scene;
    /*public Color FlashColor;
    public Color DefaultColor;
    public float FlashTime;
    public int NumOfFlashes;
    public SpriteRenderer Sprite;
    private Material FlashWhite;
    private Material FlashDefault;
    SpriteRenderer Sr;*/
    //Start is called before the first frame update

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
        }
        //StartCoroutine(FlashC());
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Die();
        }
    }
    /*private IEnumerator FlashC()
    {
        int temp = 0;
        while (temp < NumOfFlashes)
        {
            Sprite.color = FlashColor;
            yield return new WaitForSeconds(FlashTime);
            Sprite.color = DefaultColor;
            yield return new WaitForSeconds(FlashTime);
            temp++;
        }
    }*/
    void Die()
    {
    //   SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(Scene);
    }
}

