using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CubeSignalManager : MonoBehaviour
{
    public GameObject room = null;

    public CubeMaterialScriptableObject materials = null;
    public MaterialList materialList = null;

    public CubeMatrixGenerator matrices = null;

    public List<GameObject> cubes = new List<GameObject>();
    public GameObject[,] cubeMatrix;

    private int _count = 0;

    //Do you need a copy though?
    //if the matrix is refered by some more objects, 
    //then I will not need a copy
    private void GetCubeMatrix()
    {
        cubeMatrix = matrices?.cubeMatrix;
        if(cubeMatrix == null) GetCubeMatrix();
    }
  
    //rewrite all cubes
    public void ChangeCubeMaterials(ref int[,] colorMatrix)
    {
        for(int i = 0; i < colorMatrix.GetLength(0); i++)
        {
            for( int j = 0; j < colorMatrix.GetLength(1); j++)
            {
                cubeMatrix[j, i].GetComponent<Renderer>().material 
                        = materialList.materials[colorMatrix[i,j]];
            }
        }
    }

    private void Start()
    {
        GetCubeMatrix();
    }
}
