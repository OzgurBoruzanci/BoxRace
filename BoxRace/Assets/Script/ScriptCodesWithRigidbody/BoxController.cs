using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool canCollectable=true;
    //public GameObject player;
    

    bool collected;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        EventManager.Boxcollided += Boxcollided;
        EventManager.BoxcollidedToObstacle += BoxcollidedToObstacle;
        EventManager.Point += Point;
    }
    private void OnDisable()
    {
        EventManager.Boxcollided -= Boxcollided;
        EventManager.BoxcollidedToObstacle -= BoxcollidedToObstacle;
        EventManager.Point -= Point;
    }

    void Point(GameObject box)
    {

    }

    void BoxcollidedToObstacle(GameObject box)
    {
        box.transform.parent = null;
    }
    void Boxcollided(BoxController box)
    {

    }

    void Update()
    {
        
    }
    //public void Removed(GameObject box)
    //{
    //    transform.parent=null;
    //    characterController.boxs.Remove(box);
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<CharacterController>() && !collected && canCollectable)
        {
            EventManager.Boxcollided(this.gameObject.GetComponent<BoxController>());
            //characterController.CollisionWithBox(this.gameObject.GetComponent<BoxController>());
            //characterController.CollisionWithBoxPosition();
            canCollectable = false;
            collected = true;
            EventManager.Point(this.gameObject);
        }
        if (collision.transform.GetComponent<BoxController>() && collected && collision.transform.GetComponent<BoxController>().canCollectable)
        {
            EventManager.Boxcollided(collision.transform.GetComponent<BoxController>());
            //characterController.CollisionWithBox(collision.transform.GetComponent<BoxController>());
            //characterController.CollisionWithBoxPosition();
            collision.transform.GetComponent<BoxController>().canCollectable = false;
            collision.transform.GetComponent<BoxController>().collected = true;
            EventManager.Point(collision.gameObject);
        }
        if (collision.transform.GetComponent<ObstacleController>() && collision.transform.GetComponent<ObstacleController>().obstacleActive==true)
        {
            //Removed(this.gameObject);
            EventManager.BoxcollidedToObstacle(this.gameObject);
            //transform.parent = null;
        }
        
    }
}
