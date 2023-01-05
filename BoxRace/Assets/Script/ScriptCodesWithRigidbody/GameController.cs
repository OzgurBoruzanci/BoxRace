using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject levelCanvas;
    LevelControl levelControl;

    void Start()
    {
        levelControl = levelCanvas.GetComponent<LevelControl>();
        PlayerPrefs.SetInt("Record", int.Parse(SceneManager.GetActiveScene().name));
    }

    public void NextLevel()
    {
        levelControl.nextLevelControl = true;

    }
    public void GameOver()
    {
        levelControl.gameOverControl = true;
    }
}
