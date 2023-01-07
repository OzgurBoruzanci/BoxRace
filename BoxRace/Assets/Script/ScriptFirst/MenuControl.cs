using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuControl : MonoBehaviour
{
    int recordint;
    GameObject canvas;
    void Start()
    {
        recordint = PlayerPrefs.GetInt("Record");
        canvas = GameObject.Find("Canvas");

        for (int i = recordint+2 ; i < canvas.transform.GetChild(1).childCount; i++)
        {
            canvas.transform.GetChild(1).transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable = false;
            Debug.Log(recordint);
        }
    }
    private void Update()
    {

    }
    public void Play()
    {
        if (recordint == 0)
        {
            SceneManager.LoadScene("1");
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Record"));

        }
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("Record", 0);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void ButtonLevel()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void LevelOne()
    {
        SceneManager.LoadScene("1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("3");
    }
    public void Back()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("1");
    }
}
    

