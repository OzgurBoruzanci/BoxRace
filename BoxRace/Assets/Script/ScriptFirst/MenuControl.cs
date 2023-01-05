using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    void Start()
    {
        
    }
    private void Update()
    {
    }
    public void Play()
    {
        SceneManager.LoadScene("1");
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
