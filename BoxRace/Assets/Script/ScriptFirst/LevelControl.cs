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
    bool speedBool;
    int nextScene = 0;
    int recordint;

    private void OnEnable()
    {
        EventManager.SpeedRegulation += SpeedRegulation;
        EventManager.GameOverControl += GameOverControl;
        EventManager.NextLevelControl += NextLevelControl;
    }
    private void OnDisable()
    {
        EventManager.SpeedRegulation -= SpeedRegulation;
        EventManager.GameOverControl -= GameOverControl;
        EventManager.NextLevelControl -= NextLevelControl;
    }

    void Start()
    {
        levelText.text = "Level " + SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("Record", int.Parse(SceneManager.GetActiveScene().name));
        recordint = PlayerPrefs.GetInt("Record");
    }

    
    void Update()
    {
        
    }
    void SpeedRegulation()
    {
        speedBool = true;
    }
    void GameOverControl()
    {
        gameOverControl = true;
    }
    void NextLevelControl()
    {
        nextLevelControl = true;
        if (recordint == 3)
        {
            PlayerPrefs.SetInt("Record", 0);
        }
    }


    private void FixedUpdate()
    {
        if (gameOverControl == true)
        {
            EventManager.SpeedRegulation();
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
            EventManager.SpeedRegulation();
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
