using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject levelCanvas;
    //LevelControl levelControl;
    //int recordint;

    void Start()
    {
        //levelControl = levelCanvas.GetComponent<LevelControl>();
        //PlayerPrefs.SetInt("Record", int.Parse(SceneManager.GetActiveScene().name));
        //recordint = PlayerPrefs.GetInt("Record");

    }
    private void OnEnable()
    {
        EventManager.GameOverControl += GameOver;
        EventManager.NextLevelControl += NextLevel;
    }
    private void OnDisable()
    {
        EventManager.GameOverControl -= GameOver;
        EventManager.NextLevelControl -= NextLevel;
    }

    
    public void NextLevel()
    {
        EventManager.NextLevelControl();
    }
    public void GameOver()
    {
        EventManager.GameOverControl();
    }
}
