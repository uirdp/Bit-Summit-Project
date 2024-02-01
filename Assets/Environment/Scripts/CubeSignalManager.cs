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
    private void GetCubeMatrix()
    {
        cubeMatrix = matrixScript?.cubeMatrix;
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
