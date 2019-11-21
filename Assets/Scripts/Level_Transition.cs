using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Transition : MonoBehaviour
{
    public string NextScene;
    public int LevelEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < LevelEnd)
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
