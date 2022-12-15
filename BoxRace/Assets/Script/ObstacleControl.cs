using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    Mechanical mechanical;
    public GameObject player;

    private void Start()
    {
        mechanical = player.GetComponent<Mechanical>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Box")
        {
            mechanical.boxs.Remove(other.gameObject);
            //Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag=="Player")
        {
            mechanical.GameOver();
        }
    }

}