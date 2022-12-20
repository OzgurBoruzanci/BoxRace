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
        if (other.gameObject.tag=="Box")
        {
            GameObject objectbox = other.gameObject;
            if (boxs.Contains(other.gameObject) == false)
            {
                boxs.Add(objectbox);
                objectbox.transform.SetParent(transform);

                for (int i = 0; i < boxs.Count; i++)
                {
                    boxs[i].transform.localPosition = new Vector3(0, i + 0.55f, 0.5f);
                    transform.GetChild(0).transform.localPosition = new Vector3(0, boxs.Count, 0.5f);
                }
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Obstacle")
        {
            if (boxs.Count!=0)
            {
                for (int i = 0; i < boxs.Count; i++)
                {
                    boxs[i].transform.localPosition = new Vector3(0, 0.55f + i, 0.5f);
                    transform.GetChild(0).transform.localPosition = new Vector3(0, boxs.Count, 0.5f);

                }
            }
            else
            {
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0.5f);
            }
            
        }
        
        if (other.gameObject.tag == "NextLevel")
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
