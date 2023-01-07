using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject levelCanvas;
    LevelControl levelControl;
    int recordint;

    void Start()
    {
        levelControl = levelCanvas.GetComponent<LevelControl>();
        PlayerPrefs.SetInt("Record", int.Parse(SceneManager.GetActiveScene().name));
        recordint = PlayerPrefs.GetInt("Record");

    }

    public void NextLevel()
    {
        levelControl.nextLevelControl = true;
        if (recordint==3)
        {
            PlayerPrefs.SetInt("Record", 0);
        }

    }
    public void GameOver()
    {
        levelControl.gameOverControl = true;
    }
}
