using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private int x_start = -5;
    [SerializeField] private int y_start = -5;
    [SerializeField] private int z_start = -5;

    [Tooltip("length of sizes")]
    [SerializeField] private int x_length = 10;
    [SerializeField] private int y_length = 10;
    [SerializeField] private int z_length = 10;

    //generate one cube per call
    private void GenerateCube(int x, int y, int z)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Material material = cube.GetComponent<Renderer>().material;
        material.color = Color.gray;

        cube.transform.position = new Vector3(x, y, z);
        cube.transform.SetParent(transform, false);
    }

    private void GenerateRoom()
    {   
        for(int x = 0; x < x_length; x++)
        {
            for(int y = 0; y < y_length; y++)
            {
                for(int z  = 0; z < z_length; z++)
                {
                    GenerateCube(x + x_start, y + y_start, z + z_start);
                }
            }
        }
    }
    private void Awake()
    {
        GenerateRoom();
    }


}

