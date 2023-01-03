using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRb : MonoBehaviour
{
    public GameObject player;
    CharacterRg characterRg;
    float cameraPositionFloat = 0;
    Vector3 cameraPosition;
    Vector3 distanceBetween;
    void Start()
    {
        characterRg = player.GetComponent<CharacterRg>();
        distanceBetween = player.transform.position - Camera.main.transform.position;
    }

    
    void LateUpdate()
    {
        //Debug.Log(characterRg.boxsRb.Count);
        cameraPositionFloat = (float)characterRg.boxsRb.Count / 20;
        cameraPosition = new Vector3(distanceBetween.x, distanceBetween.y - cameraPositionFloat,distanceBetween.z + cameraPositionFloat);
        Camera.main.transform.position = characterRg.transform.position - cameraPosition;
    }
}
