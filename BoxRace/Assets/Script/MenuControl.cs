using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject menuCube;

    void Start()
    {
        
    }
    private void Update()
    {
        menuCube.transform.Rotate(2, 2, 2);
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
