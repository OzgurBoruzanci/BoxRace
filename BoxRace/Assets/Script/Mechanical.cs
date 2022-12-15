using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mechanical : MonoBehaviour
{
    public GameObject levelController;
    LevelControl levelControl;
    public List<GameObject> boxs;
    public float distance = 0;
    public GameObject box;
    public GameObject place;
    void Start()
    {
        distance = box.transform.position.y - place.transform.position.y;
        boxs = new List<GameObject>();
        levelControl = levelController.GetComponent<LevelControl>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            GameObject obje = other.gameObject;
            if (boxs.Contains(other.gameObject) == false)
            {
                boxs.Add(obje);
                for (int i = 0; i < boxs.Count; i++)
                {
                    boxs[i].transform.parent = transform;
                    transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                    transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.GetChild(1).transform.position.y + distance - 0.1f, transform.position.z);

                }
                if (transform.childCount > 1)
                {
                    for (int i = 2; i < transform.childCount; i++)
                    {

                        float _ = transform.GetChild(i - 1).transform.position.y + distance * 2;
                        transform.GetChild(i).transform.position = new Vector3(transform.position.x, _, transform.position.z);
                        transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2 * i) - 0.1f, transform.position.z);
                    }
                }
            }

        }
        

        if (other.gameObject.tag == "Obstacle")
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.4f);

            //symblCube = Instantiate(symbolCube);
            //symblCubes.Add(symblCube);
            //if (symblCubes.Count == 1)
            //{
            //    symblCubes[0].transform.parent = objeSymblCube.transform;
            //    Destroy(symblCubes[0]);
            //}
            //else if (symblCubes.Count == 2)
            //{
            //    Destroy(symblCubes[0]);
            //    //symblCubes[0].transform.parent = objeSymblCube.transform;
            //    symblCubes[1].transform.parent = objeSymblCube.transform;
            //    symblCubes[1].transform.position = new Vector3(transform.position.x, distance, transform.position.z - 0.25f);

            //}
            //else if (symblCubes.Count > 2)
            //{
            //    for (int i = 2; i < symblCubes.Count; i++)
            //    {
            //        Destroy(symblCubes[0]);
            //        symblCubes[i].transform.parent = objeSymblCube.transform;
            //        symblCubes[1].transform.parent = objeSymblCube.transform;
            //        symblCubes[1].transform.position = new Vector3(transform.position.x, distance, transform.position.z - 0.25f);
            //        float __ = symblCubes[i - 1].transform.position.y + distance * 2;
            //        symblCubes[i].transform.position = new Vector3(symblCubes[1].transform.position.x, __, symblCubes[1].transform.position.z);

            //    }
            //}
        }


        //if (other.gameObject.tag == "NextLevel")
        //{
        //    NextLevel();
        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (boxs.Count == 0)
            {
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            else if (boxs.Count == 1)
            {
                transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2) - 0.1f, transform.position.z);
            }
            else if (boxs.Count > 1)
            {
                transform.GetChild(1).transform.position = new Vector3(transform.position.x, distance, transform.position.z);
                transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2) - 0.1f, transform.position.z);

                if (transform.childCount > 1)
                {
                    for (int i = 2; i < transform.childCount; i++)
                    {

                        float _ = transform.GetChild(i - 1).transform.position.y + distance * 2;
                        transform.GetChild(i).transform.position = new Vector3(transform.position.x, _, transform.position.z);
                        transform.GetChild(0).transform.position = new Vector3(transform.position.x, (distance * 2 * i) - 0.1f, transform.position.z);
                    }
                }

            }
            //symblCubes.Clear();
        }
        if (other.gameObject.tag == "Finish")
        {
            if (boxs.Count > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).transform.position = new Vector3(transform.GetChild(i).transform.position.x, transform.GetChild(i).transform.position.y - distance, transform.GetChild(i).transform.position.z);
                }

            }
            else
            {
                transform.GetChild(0).transform.position = new Vector3(transform.GetChild(0).transform.position.x, -0.1f, transform.GetChild(0).transform.position.z);
            }

        }
        if (other.gameObject.tag=="NextLevel")
        {
            NextLevel();
        }

    }

    public void GameOver()
    {
        levelControl.gameOverControl = true;
    }
    public void NextLevel()
    {
        levelControl.nextLevelControl = true;

    }
}
