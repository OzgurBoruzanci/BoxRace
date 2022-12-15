using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxControl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            transform.parent = null;
            this.gameObject.tag = "SymbolBox";
            transform.position=new Vector3(transform.position.x,transform.position.y,other.transform.position.z-0.325f);
        }
        
    }
}
