using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRg : MonoBehaviour
{
    public List<GameObject> boxsRb;
    void Start()
    {
        boxsRb = new List<GameObject>();
        //boxsRb.Clear();
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Box")
        {
            for (int i = 0; i < boxsRb.Count; i++)
            {
                boxsRb[i].transform.localPosition = new Vector3( 0, (- i), 0);
                transform.localPosition = new Vector3(0, (1+ i), 0);
                Debug.Log(boxsRb.Count);
            }
        }
    }
}
