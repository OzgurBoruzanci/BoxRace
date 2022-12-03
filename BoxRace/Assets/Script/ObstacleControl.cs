using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    CharacterControl characterControl;
    public GameObject player;

    private void Start()
    {
        characterControl = player.GetComponent<CharacterControl>();
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Cube")
        {
            characterControl.cubes.Remove(other.gameObject);
            Destroy(other.gameObject);
            //Debug.Log(characterControl.cubes.Count);

        }
    }

}