using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishControl : MonoBehaviour
{
    GameController gameController;
    bool canCollision=true;
    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<BoxController>() && canCollision)
        {
            collision.transform.GetComponent<BoxController>().Removed(collision.gameObject);
            canCollision = false;
        }
        if (collision.transform.GetComponent<CharacterController>() && canCollision)
        {
            gameController.NextLevel();
            collision.transform.parent.transform.GetComponent<CharacterMoveController>().speed = 0;
        }
    }



}
