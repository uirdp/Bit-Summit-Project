using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMatrixGenerator : MonoBehaviour
{
    public GameObject room = null;

    public CubeMaterialScriptableObject materials = null;
    public List<GameObject> cubes = new List<GameObject>();

    public int rows;
    public int columns;
    public GameObject[,] cubeMatrix = null;

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

        else { Debug.Log("there is no room"); }
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
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cubeMatrix[i, j] = room.transform.GetChild(ind).gameObject;
                    ind++;
                }
            }
        }

        else { Debug.Log("there is no room"); }
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

}
