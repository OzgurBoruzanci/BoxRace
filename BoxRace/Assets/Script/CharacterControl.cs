using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    List<GameObject> cubes;
    float horizontal = 0;
    float distance = 0;

    Vector3 distanceBetween;
    Vector3 newCube;
    public GameObject obtained;
    public GameObject cube;
    public GameObject plane;
    

    
    void Start()
    {
        distance=cube.transform.position.y-plane.transform.position.y;
        

        cubes=new List<GameObject>();
        distanceBetween = transform.position - Camera.main.transform.position;
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Cube")
    //    {
    //        Destroy(other.gameObject);
    //        Instantiate(cube, newCube, transform.rotation);
    //        cubes.Add(cube);
    //        for (int i = 0; i < cubes.Count; i++)
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y + distance * 2, transform.position.z);
    //            cubes[i].transform.position = transform.position;
    //        }
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
            Instantiate(cube, newCube, transform.rotation);
            cubes.Add(cube);
            for (int i = 0; i < cubes.Count; i++)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f * 2, transform.position.z);
                cubes[i].transform.position = transform.position;
            }
        }
    }


    private void LateUpdate()
    {
        CameraControl();
    }
    void Update()
    {
        MoveControl();
        obtained.transform.position = new Vector3(transform.position.x, 0 + 0.25f, transform.position.z);
        newCube = new Vector3(transform.position.x, 0.25f, transform.position.z);

        //for (int i = 0; i < cubes.Count; i++)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + distance * 2, transform.position.z);
        //    Debug.Log(distance);

        //    cubes[i].transform.position = new Vector3(transform.position.x, i * distance * 2, transform.position.z);
        //}

    }

    
    
    void MoveControl()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector3 vec = new Vector3(horizontal, 0, 2);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 3;
    }

    void CameraControl()
    {
        Camera.main.transform.position = transform.position - distanceBetween;
    }
}
