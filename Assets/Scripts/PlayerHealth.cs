using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    GameObject player;
    public int health;
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
  
        if(player.transform.position.y < -4)
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
}
