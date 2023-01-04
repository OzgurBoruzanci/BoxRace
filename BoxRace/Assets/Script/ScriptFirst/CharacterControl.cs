using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class CharacterControl : MonoBehaviour
{
    float horizontal = 0;

    float placeWidth = 0;
    float placeLenght = 0;

    public GameObject place;

    public float speed = 1.7f;


    void Start()
    {
        Time.timeScale = 1;
        placeWidth = place.GetComponent<Collider>().bounds.size.x/2;
        placeLenght=place.GetComponent<Collider>().bounds.size.z/2;

    }


    private void LateUpdate()
    {
        MoveControl();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
        }
        

        //if (gameOverControl==false)
        //{
        //    KeyControl();
        //}

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
        transform.position += vec * Time.deltaTime * 5;
    }
    void KeyControl()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        Vector3 vec = new Vector3(horizontal, 0, 1.5f);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 4;
        
    }
}

