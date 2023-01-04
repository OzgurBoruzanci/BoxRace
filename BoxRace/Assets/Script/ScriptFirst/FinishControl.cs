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
            //other.gameObject.transform.position= new Vector3(characterControl.transform.position.x, mechanical.distance, characterControl.transform.position.z - 0.5f);
        }
        if (collision.transform.GetComponent<CharacterController>() && canCollision)
        {
            Debug.Log(collision.gameObject.tag);
            gameController.NextLevel();
            Time.timeScale = 0;
            //characterControl.speed = 0.5f;
        }
    }



}
