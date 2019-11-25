using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("First Level Design");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Lava Level");
    }

}
