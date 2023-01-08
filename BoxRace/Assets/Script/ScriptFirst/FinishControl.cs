using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishControl : MonoBehaviour
{
    //GameController gameController;
    bool canCollision=true;
    
    void Start()
    {
        //gameController = FindObjectOfType<GameController>();
    }
    private void OnEnable()
    {
        EventManager.NextLevelControl += NextLevelControl;
    }
    private void OnDisable()
    {
        EventManager.NextLevelControl += NextLevelControl;
    }
    void NextLevelControl()
    {

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
            EventManager.NextLevelControl();
            //collision.transform.parent.transform.GetComponent<CharacterMoveController>().speed = 0;
        }
    }



}
