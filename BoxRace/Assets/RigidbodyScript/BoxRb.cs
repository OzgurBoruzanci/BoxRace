using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (collision.transform.GetComponent<CharacterRg>() && collectable == true)
        {
            transform.parent = collision.gameObject.transform;
            //Debug.Log(transform.parent.name);
            collision.transform.GetComponent<CharacterRg>().boxsRb.Add(this.gameObject);
            collectable = false;
        }
        if (collision.transform.GetComponent<BoxRb>() && collectable==true)
        {
            transform.parent = collision.gameObject.transform;
            if (collision.transform.GetComponent<CharacterRg>().boxsRb.Contains(collision.gameObject) == false)
            {
                collision.transform.GetComponent<CharacterRg>().boxsRb.Add(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Obstacle" /*&& GameObject.FindObjectOfType<ObstacleRb>().obstacleBool == true*/)
        {
            gameObject.transform.parent = null;
            //GameObject.FindObjectOfType<ObstacleRb>().obstacleBool = false;
            //Debug.Log(GameObject.FindObjectOfType<ObstacleRb>().obstacleBool);
        }
    }
}
