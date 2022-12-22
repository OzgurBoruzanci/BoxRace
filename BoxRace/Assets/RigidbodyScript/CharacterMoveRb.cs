using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveRb : MonoBehaviour
{
    float horizontal = 0;

    float placeWidth = 0;
    float placeLenght = 0;

    public GameObject place;
    void Start()
    {
        Time.timeScale = 1;
        placeWidth = place.GetComponent<Collider>().bounds.size.x / 2;
        placeLenght = place.GetComponent<Collider>().bounds.size.z / 2;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
        }
    }
    private void LateUpdate()
    {
        MoveControl();
    }
    void MoveControl()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (-placeWidth), placeWidth);
        viewPos.z = Mathf.Clamp(viewPos.z, (-placeLenght), placeLenght);
        //viewPos.y = Mathf.Clamp(viewPos.y, 0, 50);
        transform.position = viewPos;
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        Vector3 vec = new Vector3(horizontal, 0, 1.7f);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime*5f;
    }
}
