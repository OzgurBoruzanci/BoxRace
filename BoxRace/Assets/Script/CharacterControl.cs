using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class CharacterControl : MonoBehaviour
{
    public List<GameObject> cubes;
    public List<GameObject> symblCubes;
    int nextScene = 0;
    float horizontal = 0;
    float menuTime=0;
    float gameOverCounter = 0;
    public float distance = 0;

    Vector3 distanceBetween;
    
    //public GameObject player;
    public GameObject cube;
    public GameObject symbolCube;
    public GameObject objeSymblCube;
    public GameObject plane;
    public Text gameOverText;
    public Text nextLevelText;
    GameObject symblCube;
    public bool gameOverControl = false;
    public bool nextLevelControl = false;


    void Start()
    {
        Time.timeScale = 1;
        distance = cube.transform.position.y - plane.transform.position.y;
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
            if (cubes.Contains(other.gameObject) == false)
            {
                cubes.Add(obje);

                for (int i = 0; i < cubes.Count; i++)
                {
                    cubes[i].transform.parent = transform;
                    transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                    transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.GetChild(1).transform.position.y + distance - 0.1f, transform.position.z);

                }
                if (transform.childCount > 1)
                {
                    for (int i = 2; i < transform.childCount; i++)
                    {

                        float _ = transform.GetChild(i - 1).transform.position.y + distance * 2;
                        transform.GetChild(i).transform.position = new Vector3(transform.position.x, _, transform.position.z);
                        transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2*i) - 0.1f, transform.position.z);
                    }
                }
            }
        }

        if (other.gameObject.tag == "Obstacle")
        {
            
            symblCube= Instantiate(symbolCube);
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


        if (other.gameObject.tag == "NextLevel")
        {
            NextLevel();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (cubes.Count == 0)
            {
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            else if (cubes.Count == 1)
            {
                transform.GetChild(1).transform.position = new Vector3(transform.position.x,distance,transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance*2) - 0.1f, transform.position.z);
            }
            else if(cubes.Count > 1)
            {
                transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2) - 0.1f, transform.position.z);

                if (transform.childCount > 1)
                {
                    for (int i = 2; i < transform.childCount; i++)
                    {

                        float _ = transform.GetChild(i - 1).transform.position.y + distance * 2;
                        transform.GetChild(i).transform.position = new Vector3(transform.position.x, _, transform.position.z);
                        transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2*i) - 0.1f, transform.position.z);
                    }
                }

            }
            symblCubes.Clear();
        }
        if (other.gameObject.tag == "Finish")
        {
            if (cubes.Count>0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).transform.position = new Vector3(transform.GetChild(i).transform.position.x, transform.GetChild(i).transform.position.y - distance, transform.GetChild(i).transform.position.z);
                }

            }
            else
            {
                transform.GetChild(0).transform.position=new Vector3(transform.GetChild(0).transform.position.x, -0.1f,transform.GetChild(0).transform.position.z);
            }
            
        }

    }


    private void LateUpdate()
    {
        CameraControl();
    }
    void Update()
    {
        if (gameOverControl==false)
        {
            MoveControl();
        }
        

    }
    private void FixedUpdate()
    {
        if (gameOverControl == true)
        {
            Time.timeScale = 0.4f;
            gameOverCounter += 0.01f;
            gameOverText.text = "GAME OVER";
            menuTime += Time.deltaTime;
            if (menuTime > 1.3f)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (nextLevelControl==true)
        {
            Time.timeScale = 0.4f;
            menuTime += Time.deltaTime;
            nextLevelText.text = "COMPLETED";
            if (menuTime>1.3f)
            {
                nextScene = int.Parse(SceneManager.GetActiveScene().name) + 1;
                if (nextScene != 4)
                {
                    SceneManager.LoadScene($"{nextScene}");
                }
                else if (nextScene == 4)
                {
                    SceneManager.LoadScene("Menu");
                }
            }
        }
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

    public void GameOver()
    {
        gameOverControl = true;
    }
    public void NextLevel()
    {
        nextLevelControl = true;
    }
}

