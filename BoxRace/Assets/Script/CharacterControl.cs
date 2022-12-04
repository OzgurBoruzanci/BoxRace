using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterControl : MonoBehaviour
{
    public List<GameObject> cubes;
    List<GameObject> symblCubes;
    float horizontal = 0;
    float distance = 0;

    Vector3 distanceBetween;
    
    //public GameObject player;
    public GameObject cube;
    public GameObject symbolCube;
    public GameObject objeSymblCube;
    public GameObject plane;

    

    void Start()
    {
        distance= cube.transform.position.y - plane.transform.position.y;
        //Debug.Log(distance + "   iki katı  ==" + distance * 2);
        
        cubes =new List<GameObject>();
        symblCubes =new List<GameObject>();
       
        distanceBetween = transform.position - Camera.main.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            GameObject obje = other.gameObject;
            if (cubes.Contains(other.gameObject)==false)
            {
                cubes.Add(obje);
            }
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].transform.parent = transform;
                transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.GetChild(1).transform.position.y + distance, transform.position.z);
                
            }
            if (transform.childCount > 1)
            {
                for (int i = 2; i < transform.childCount; i++)
                {

                    float _ = transform.GetChild(i - 1).transform.position.y + distance * 2;
                    transform.GetChild(i).transform.position = new Vector3(transform.position.x, _, transform.position.z);
                    transform.GetChild(0).transform.position = new Vector3(transform.position.x, distance * 2 * i, transform.position.z);
                }
            }
        }

        if (other.gameObject.tag == "Obstacle")
        {
            
            GameObject symblCube= Instantiate(symbolCube);
            symblCubes.Add(symblCube);
            if (symblCubes.Count==1)
            {
                symblCubes[0].transform.parent = objeSymblCube.transform;
                Destroy(symblCubes[0]);
            }
            else if (symblCubes.Count==2)
            {
                Destroy(symblCubes[0]);
                //symblCubes[0].transform.parent = objeSymblCube.transform;
                symblCubes[1].transform.parent = objeSymblCube.transform;
                symblCubes[1].transform.position = new Vector3(transform.position.x, distance, transform.position.z - 0.25f);
                
            }
            else if (symblCubes.Count>2)
            {
                for (int i = 2; i < symblCubes.Count; i++)
                {
                    Destroy(symblCubes[0]);
                    symblCubes[i].transform.parent = objeSymblCube.transform;
                    symblCubes[1].transform.parent = objeSymblCube.transform;
                    symblCubes[1].transform.position = new Vector3(transform.position.x, distance, transform.position.z - 0.25f);
                    float __ = symblCubes[i - 1].transform.position.y + distance * 2;
                    symblCubes[i].transform.position = new Vector3(symblCubes[1].transform.position.x, __, symblCubes[1].transform.position.z);
                   
                }
            }
        }

        if (other.gameObject.tag == "Finish")
        {
            Debug.Log(cubes.Count);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (cubes.Count == 0)
            {
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            else if (cubes.Count == 1)
            {
                transform.GetChild(1).transform.position = new Vector3(transform.position.x,distance,transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, distance * 2, transform.position.z);
            }
            else if(cubes.Count > 1)
            {
                transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, distance * 2, transform.position.z);

                if (transform.childCount > 1)
                {
                    for (int i = 2; i < transform.childCount; i++)
                    {

                        float _ = transform.GetChild(i - 1).transform.position.y + distance * 2;
                        transform.GetChild(i).transform.position = new Vector3(transform.position.x, _, transform.position.z);
                        transform.GetChild(0).transform.position = new Vector3(transform.position.x, distance * 2 * i, transform.position.z);
                    }
                }

            }
            symblCubes.Clear();
        }

    }


    private void LateUpdate()
    {
        CameraControl();
    }
    void Update()
    {
        MoveControl();

    }

    
    
    void MoveControl()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector3 vec = new Vector3(horizontal, 0, 1.5f);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 4;
    }

    void CameraControl()
    {
        Camera.main.transform.position = transform.position - distanceBetween;
    }
}

