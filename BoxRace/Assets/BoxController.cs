using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool canCollectable=true;
    //public GameObject player;
    CharacterController characterController;
    void Start()
    {
        characterController=FindObjectOfType<CharacterController>();
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
        if (collision.transform.GetComponent<CharacterController>() && canCollectable)
        {
            characterController.CollisionWithBox(this.gameObject.GetComponent<BoxController>());
            characterController.CollisionWithBoxPosition();
            canCollectable = false;
        }
        if (collision.transform.GetComponent<BoxController>() && collision.transform.GetComponent<BoxController>().canCollectable)
        {
            characterController.CollisionWithBox(collision.transform.GetComponent<BoxController>());
            characterController.CollisionWithBoxPosition();
            collision.transform.GetComponent<BoxController>().canCollectable = false;
        }
        if (collision.transform.GetComponent<ObstacleController>() && collision.transform.GetComponent<ObstacleController>().obstacleActive==true)
        {
            Removed(this.gameObject);
        }
    }
}
