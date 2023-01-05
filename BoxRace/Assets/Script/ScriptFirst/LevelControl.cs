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
    public Text levelText;
    public Text gameOverText;
    public Text nextLevelText;
    float menuTime = 0;
    float gameOverCounter = 0;
    int nextScene = 0;
    CharacterMoveController moveController;
    void Start()
    {
        levelText.text = "Level " + SceneManager.GetActiveScene().name;
        moveController=FindObjectOfType<CharacterMoveController>();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (gameOverControl == true)
        {
            moveController.speed = 0;
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
