using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRb : MonoBehaviour
{
    public bool collectable = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<BoxRb>() && collectable == true)
        {
            transform.parent = collision.gameObject.transform;
            //Debug.Log(transform.parent.name);
            GameObject.FindObjectOfType<CharacterRg>().boxsRb.Add(this.gameObject);
            collectable = false;
        }
        if (collision.gameObject.tag == "Obstacle" /*&& GameObject.FindObjectOfType<ObstacleRb>().obstacleBool == true*/)
        {
            gameObject.transform.parent = null;
            //GameObject.FindObjectOfType<ObstacleRb>().obstacleBool = false;
            //Debug.Log(GameObject.FindObjectOfType<ObstacleRb>().obstacleBool);
        }
    }
}
