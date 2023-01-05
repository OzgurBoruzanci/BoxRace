using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool canCollectable=true;
    //public GameObject player;
    GameController gameController;
    CharacterController characterController;
    bool collected;
    void Start()
    {
        characterController=FindObjectOfType<CharacterController>();
        gameController = FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        
    }
    public void Removed(GameObject box)
    {
        transform.parent=null;
        characterController.boxs.Remove(box);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<CharacterController>() && !collected && canCollectable)
        {
            characterController.CollisionWithBox(this.gameObject.GetComponent<BoxController>());
            characterController.CollisionWithBoxPosition();
            canCollectable = false;
            collected = true;
        }
        if (collision.transform.GetComponent<BoxController>() && collected && collision.transform.GetComponent<BoxController>().canCollectable)
        {
            characterController.CollisionWithBox(collision.transform.GetComponent<BoxController>());
            characterController.CollisionWithBoxPosition();
            collision.transform.GetComponent<BoxController>().canCollectable = false;
            collision.transform.GetComponent<BoxController>().collected = true;
        }
        if (collision.transform.GetComponent<ObstacleController>() && collision.transform.GetComponent<ObstacleController>().obstacleActive==true)
        {
            Removed(this.gameObject);
        }
        
    }
}
