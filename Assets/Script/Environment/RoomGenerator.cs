using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Apple;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private int x_start = -5;
    [SerializeField] private int y_start = -5;
    [SerializeField] private int z_start = -5;

    [Tooltip("length of sides")]
    [SerializeField] private int x_length = 10;
    [SerializeField] private int y_length = 10;
    [SerializeField] private int z_length = 10;

    public Color baseColor = Color.gray;
    public Texture CubeTexture = null;

    //generate one cube per call
    private void GenerateCube(float x, float y, float z)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Material material = cube.GetComponent<Renderer>().sharedMaterial;
        material.color = baseColor;

        if(CubeTexture != null)
        {
            material.mainTexture = CubeTexture;
        }

        cube.transform.position = new Vector3(x, y, z);
        cube.transform.SetParent(transform, false);
    }

    [ContextMenu("Destory Room")]
    private void DestroyRoom()
    {
        //need to iterate for some times to get rid of the children entirely, for some reason
        int cap = (x_length + y_length + z_length) >> 1;
        for (int i = 0; i < cap; i++)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }

    [ContextMenu("Generate Room")]
    private void GenerateRoom()
    {
        DestroyRoom();

        for(int x = 0; x < x_length; x++)
        {
            for(int y = 0; y < y_length; y++)
            {
                for(int z  = 0; z < z_length; z++)
                {   
                    // I do NOT like this algorithm, there surely  is a better way
                    if (x == 0 || x == x_length - 1 ||
                        y == 0 || y == y_length - 1 ||
                        z == 0 || z == z_length - 1)
                    {
                        GenerateCube(x + x_start, y + y_start, z + z_start);
                    }
                }
            }
        }
    }

    [ContextMenu("Generate Floor")]
    private void GenerateFloor()
    {
        DestroyRoom();

        Debug.Log(transform.position.y);
        for (int x = 0; x < x_length; x++)
        {
            for(int z = 0; z < z_length; z++)
            {
                GenerateCube(x + x_start, transform.position.y, z + z_start);
            }
        }
    }
}

