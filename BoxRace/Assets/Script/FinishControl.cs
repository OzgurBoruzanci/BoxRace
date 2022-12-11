using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishControl : MonoBehaviour
{
    CharacterControl characterControl;
    public GameObject player;
    
    void Start()
    {
        characterControl = player.GetComponent<CharacterControl>();
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            characterControl.cubes.Remove(other.gameObject);
            Destroy(other.gameObject);

            GameObject symblCube = Instantiate(characterControl.symbolCube);
            characterControl.symblCubes.Add(symblCube);
            //characterControl.symblCubes[0].transform.parent = characterControl.objeSymblCube.transform;
            characterControl.symblCubes[0].transform.parent = characterControl.objeSymblCube.transform;
            characterControl.symblCubes[0].transform.position = new Vector3(characterControl.transform.position.x, characterControl.distance, characterControl.transform.position.z - 0.5f);

            //Destroy(characterControl.symblCubes[0]);
            characterControl.symblCubes.Clear();
        }
        if (other.gameObject.tag == "Player")
        {
            //characterControl.GameOver();
            characterControl.NextLevel();
        }
    }



}
