using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    Mechanical mechanical;
    float cameraPositionFloat = 0;
    Vector3 cameraPosition;
    Vector3 distanceBetween;
    void Start()
    {
        mechanical = player.GetComponent<Mechanical>();
        distanceBetween = player.transform.position - Camera.main.transform.position;
    }

    
    void LateUpdate()
    {
        cameraPositionFloat = (float)mechanical.boxs.Count / 5;
        cameraPosition = new Vector3(distanceBetween.x, distanceBetween.y - cameraPositionFloat,distanceBetween.z + cameraPositionFloat);
        Camera.main.transform.position = mechanical.transform.position - cameraPosition;
    }
}
