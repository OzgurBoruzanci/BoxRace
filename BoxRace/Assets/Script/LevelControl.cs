using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{

    public bool gameOverControl = false;
    public bool nextLevelControl = false;
    public Text gameOverText;
    public Text nextLevelText;
    float menuTime = 0;
    float gameOverCounter = 0;
    int nextScene = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (gameOverControl == true)
        {
            Time.timeScale = 0.0f;
            gameOverCounter += 0.01f;
            gameOverText.text = "GAME OVER";
            menuTime += Time.deltaTime;
            if (menuTime > 1.3f)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (nextLevelControl == true)
        {
            Time.timeScale = 0.4f;
            menuTime += Time.deltaTime;
            nextLevelText.text = "COMPLETED";
            if (menuTime > 1.3f)
            {
                nextScene = int.Parse(SceneManager.GetActiveScene().name) + 1;
                if (nextScene != 4)
                {
                    SceneManager.LoadScene($"{nextScene}");
                }
                else if (nextScene == 4)
                {
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
