using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject levelController;
    LevelControl levelControl;

    void Start()
    {
        levelControl = levelController.GetComponent<LevelControl>();
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
