using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public bool obstacleActive=true;
    GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<BoxController>() && obstacleActive)
        {
            obstacleActive = false;
        }
        if (collision.transform.GetComponent<CharacterController>() && obstacleActive)
        {
            gameController.GameOver();
            Time.timeScale = 0;
        }
    }
}
