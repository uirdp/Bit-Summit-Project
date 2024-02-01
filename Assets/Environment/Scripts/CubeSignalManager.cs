using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CubeSignalManager : MonoBehaviour
{
    public GameObject room = null;

    public CubeMaterialScriptableObject materials = null;
    public List<GameObject> cubes = new List<GameObject>();


    public int rows;
    public int columns;
    public GameObject[,] cubeMatrix = null;

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

    private void CreateMatrixFromGroupNumber()
    {
        
    }

    [ContextMenu("Create Matrix With Position")]
    private void CreateMatrixWithPosition()
    {
        if (cubeMatrix == null) cubeMatrix = new GameObject[rows, columns];

        int ind = 0;
        if (room != null)
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    cubeMatrix[i, j] = room.transform.GetChild(ind).gameObject;
                    ind++;
                }
            }
        }

        else { Debug.Log("there is no room");  }
    }

    [ContextMenu("CheckMatrix")]
    private void CheckMatrix()
    {
        if (cubeMatrix != null)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Debug.Log("(" + i + "," + j + ") = " + cubeMatrix[i, j]);
                }
            }
        }

        else Debug.Log("there is no matrix");
    }

    private IEnumerator SendSignal()
    { 
        
        cubes[_count].GetComponent<Renderer>().material = materials?.dangerousMaterial; 
        yield return new WaitForSeconds(0.5f);
        cubes[_count].GetComponent<Renderer>().material = materials?.defaultMaterial;
        
        _count++;
        if (_count == cubes.Count) _count = 0; 
        StartCoroutine(SendSignal());
    }

    private IEnumerator SwitchCubeMaterialsWithGroupNumber(int groupNum)
    {
        yield return null;
    }
    private IEnumerator SwitchCubeMaterialsWithColorMatrix(int x, int z, int xsz, int zsz)
    {
        for(int i = 0; i < xsz; i++)
        {
            for(int j = 0; z < zsz; z++)
            {
                cubeMatrix[x + i, z + j].GetComponent<Renderer>().material = materials?.dangerousMaterial;
            }
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < xsz; i++)
        {
            for (int j = 0; z < zsz; z++)
            {
                cubeMatrix[x + i, z + j].GetComponent<Renderer>().material = materials?.dangerousMaterial;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(SendSignal());
    }
}
