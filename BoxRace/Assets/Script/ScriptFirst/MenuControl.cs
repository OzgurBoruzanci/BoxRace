using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuControl : MonoBehaviour
{
    int recordint;
    void Start()
    {
        recordint = PlayerPrefs.GetInt("Record");

        for (int i = recordint+2 ; i < transform.GetChild(1).childCount; i++)
        {
            transform.GetChild(1).transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable = false;
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
       transform.GetChild(0).gameObject.SetActive(false);
       transform.GetChild(1).gameObject.SetActive(true);
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
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("1");
    }
}
    

