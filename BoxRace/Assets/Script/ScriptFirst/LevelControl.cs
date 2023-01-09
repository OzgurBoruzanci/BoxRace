using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    List<GameObject> pointList;
    public bool gameOverControl = false;
    public bool nextLevelControl = false;
    public Text levelText;
    public Text gameOverText;
    public Text nextLevelText;
    public Text pointText;
    float menuTime = 0;
    int nextScene = 0;
    int recordint;

    private void OnEnable()
    {
        EventManager.SpeedRegulation += SpeedRegulation;
        EventManager.GameOverControl += GameOverControl;
        EventManager.NextLevelControl += NextLevelControl;
        EventManager.Point += Point;
    }
    private void OnDisable()
    {
        EventManager.SpeedRegulation -= SpeedRegulation;
        EventManager.GameOverControl -= GameOverControl;
        EventManager.NextLevelControl -= NextLevelControl;
        EventManager.Point -= Point;
    }

    void Start()
    {
        levelText.text = "Level " + SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("Record", int.Parse(SceneManager.GetActiveScene().name));
        recordint = PlayerPrefs.GetInt("Record");
        pointList=new List<GameObject>();
    }

    
    void Update()
    {
        
    }
    void Point(GameObject box)
    {
        pointList.Add(box);
        pointText.text = "POİNT : "+(pointList.Count*5);
    }
    void SpeedRegulation()
    {
        
    }
    void GameOverControl()
    {
        gameOverControl = true;
        if (gameOverControl == true)
        {
            EventManager.SpeedRegulation();
            gameOverText.text = "GAME OVER";
        }
    }
    void NextLevelControl()
    {
        nextLevelControl = true;
        if (recordint == 3)
        {
            PlayerPrefs.SetInt("Record", 0);
        }
        if (nextLevelControl == true)
        {
            EventManager.SpeedRegulation();
            Time.timeScale = 0.4f;
            nextLevelText.text = "COMPLETED";
        }
    }

    private void FixedUpdate()
    {
        if (gameOverControl == true)
        {
            menuTime += Time.deltaTime;
            if (menuTime > 1.3f)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (nextLevelControl == true)
        {
            menuTime += Time.deltaTime;
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
