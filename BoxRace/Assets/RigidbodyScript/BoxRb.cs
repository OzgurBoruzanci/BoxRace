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
        if (collision.gameObject.tag=="Player" && collectable == true)
        {
            transform.parent = collision.gameObject.transform.parent;
            GameObject.FindObjectOfType<CharacterRg>().boxsRb.Add(this.gameObject);
            collectable = false;
        }
        if (collision.gameObject.tag=="Obstacle")
        {
            transform.parent = null;
        }
    }
}
