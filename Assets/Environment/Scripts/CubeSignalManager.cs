using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CubeSignalManager : MonoBehaviour
{
    public GameObject room = null;

    public CubeMaterialScriptableObject materials = null;
    public CubeMatrixGenerator matrixScript = null;

    public List<GameObject> cubes = new List<GameObject>();
    public GameObject[,] cubeMatrix = null;

    private int _count = 0;

    //Do you need a copy though?
    //if the matrix is refered by some more objects, 
    //then I will not need a copy
    private void GetCubeMatrix()
    {
        cubeMatrix = matrixScript?.cubeMatrix;
    }

    //should be renamed to ChangeMaterial
    private IEnumerator SendSignal()
    { 
        
        cubes[_count].GetComponent<Renderer>().material = materials?.dangerousMaterial; 
        yield return new WaitForSeconds(0.5f);
        cubes[_count].GetComponent<Renderer>().material = materials?.defaultMaterial;
        
        _count++;
        if (_count == cubes.Count) _count = 0; 
        StartCoroutine(SendSignal());
    }

    //not sure if I am gonna need this
    //changes color by group number, which is assign to cubes individually
    private IEnumerator SwitchCubeMaterialsWithGroupNumber(int groupNum)
    {
        yield return null;
    }

    //use color colour matrix's index to switch colors
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
