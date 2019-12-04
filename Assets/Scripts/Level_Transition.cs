using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Transition : MonoBehaviour
{
    public int endOfLevel = 390;
    private string grassLevel = "First Level Design";
    private string lavaLevel = "LavaLevel";
    private string menu = "Menu";

    void Update()
    {
        endOfLevel = SceneManager.GetActiveScene().name == grassLevel ? 390 : 25;
        SceneHandler();
    }

    void SceneHandler()
    {
        if (SceneManager.GetActiveScene().name == grassLevel)
        {
            if (gameObject.transform.position.x > endOfLevel)
            {
                SceneManager.LoadScene(lavaLevel);
            }
        }
        else if (SceneManager.GetActiveScene().name == lavaLevel)
        {
            
            if (gameObject.transform.position.x > endOfLevel)
            {
                SceneManager.LoadScene(menu);
            }
        }
    }
}
