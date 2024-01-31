using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSignalManager : MonoBehaviour
{
    public GameObject room = null;
    public List<GameObject> cubes = new List<GameObject>();

    private int _count = 0;


    [ContextMenu("Make List")]
    private void MakeList()
    {
        if (room != null)
        {
            if (cubes?.Count == 0)
            {
                foreach (Transform child in room.transform)
                {
                    cubes.Add(child.gameObject);
                }
            }

            else
            {
                Debug.Log("Cube list already exist");
            }
        }

        else { Debug.Log("there is no room");  }
    }

    /*+private IEnumerator SendSignal()
    {
       
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
