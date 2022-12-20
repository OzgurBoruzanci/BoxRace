using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishControl : MonoBehaviour
{
    CharacterControl characterControl;
    public GameObject player;
    Mechanical mechanical;
    
    void Start()
    {
        characterControl = player.GetComponent<CharacterControl>();
        mechanical = player.GetComponent<Mechanical>();
        
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            other.gameObject.transform.parent = null;
            other.gameObject.transform.position= new Vector3(characterControl.transform.position.x, mechanical.distance, characterControl.transform.position.z - 0.5f);
        }
        if (other.gameObject.tag=="Player")
        {
            mechanical.NextLevel();
            characterControl.speed = 0.5f;
        }
    }



}
