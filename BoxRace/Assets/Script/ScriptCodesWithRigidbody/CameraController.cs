using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    CharacterController characterController;
    float cameraPositionFloat = 0;
    Vector3 cameraPosition;
    Vector3 distanceBetween;
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        distanceBetween = player.transform.position - Camera.main.transform.position;
    }


    void LateUpdate()
    {
        //Debug.Log(characterRg.boxsRb.Count);
        cameraPositionFloat = (float)characterController.boxs.Count / 20;
        cameraPosition = new Vector3(distanceBetween.x, distanceBetween.y - cameraPositionFloat, distanceBetween.z + cameraPositionFloat);
        Camera.main.transform.position = characterController.transform.position - cameraPosition;
    }
}
