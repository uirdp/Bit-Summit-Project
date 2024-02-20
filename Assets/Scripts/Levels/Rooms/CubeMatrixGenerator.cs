using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Should Be renamed to cubematrix
public class CubeMatrixGenerator : MonoBehaviour
{
    public GameObject room = null;

    public MaterialList materials = null;
    public List<GameObject> cubes = new List<GameObject>();

    public int rows;
    public int columns;

    public GameObject[,] cubeMatrix = null;
    public int[,] colorMatrix = null;

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
        SortCubeList();
        
    }

    [ContextMenu("Sort Matrix")]
    private void SortCubeList()
    {
        //cubes?.Sort((obj1, obj2) => char.Compare(obj1.name[1],obj2.name));
    }

    private void CreateMatrixFromGroupNumber()
    {

    }

    [ContextMenu("Create Matrices With Position")]
    private void CreateMatricesWithPosition()
    {
        cubeMatrix = new GameObject[rows, columns];
        colorMatrix = new int[rows, columns];

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

    private void Awake()
    {
        CreateMatricesWithPosition();
    }

}
