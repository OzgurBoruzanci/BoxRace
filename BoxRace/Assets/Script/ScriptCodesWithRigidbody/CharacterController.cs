using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<GameObject> boxs;
    GameController gameController;
    void Start()
    {
        boxs = new List<GameObject>();
        gameController = FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        
    }

    public void CollisionWithBox(BoxController box)
    {
        boxs.Add(box.gameObject);
        box.gameObject.transform.parent = transform.parent.transform;
    }

    public void CollisionWithBoxPosition()
    {
        for (int i = 0; i < boxs.Count; i++)
        {
            boxs[i].transform.localPosition = new Vector3(0, (0.5f + i), 0);
            transform.localPosition = new Vector3(0, (1.5f + i), 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="NextLevel")
        {
            gameController.NextLevel();
            this.transform.parent.transform.GetComponent<CharacterMoveController>().speed = 0.01f;
        }
        if (collision.transform.GetComponent<ObstacleController>() && collision.transform.GetComponent<ObstacleController>().obstacleActive)
        {
            gameController.GameOver();
        }
    }
}
