using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public enum RoomType
{
    level,
    background
}

//this code is a mess, sorry 
public class RoomGenerator : MonoBehaviour
{
    private int x_start = 0;
    private int y_start = 0;
    private int z_start = 0;

    [Tooltip("length of sides")]
    [SerializeField] private int x_length = 10;
    [SerializeField] private int y_length = 10;
    [SerializeField] private int z_length = 10;

    public string roomName = null;

    public Color baseColor = Color.gray;
    public Texture CubeTexture = null;

    public MaterialList cubeMaterial = null;
    [Tooltip("material to apply")]
    public MaterialList.MaterialName MatName;
    public RoomType roomType;

    public List<GameObject> cubes = new List<GameObject>();
    [Tooltip("set to true if you want them in a list")]
    public bool makeList = false;

    public bool makeMatText = true;
    public StringBuilder matTxt = new StringBuilder();

    //generate one cube per call
    private void GenerateCube(float x, float y, float z)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Material material = cube.GetComponent<Renderer>().sharedMaterial;
        material.color = baseColor;

        if (CubeTexture != null)
        {
            material.mainTexture = CubeTexture;
        }

        cube.transform.position = new Vector3(x, y, z);
        cube.transform.SetParent(transform, false);

        cube.name = "Cube " + x + "-" + y + "-" + z;

        if(makeList && cube != null) { cubes.Add(cube); }
    }

    [ContextMenu("Destory Room")]
    private void DestroyRoom()
    {
        matTxt.Clear();
        //need to iterate for some times to get rid of the children entirely, for some reason
        int cap = (x_length + y_length + z_length) >> 1;
        for (int i = 0; i < cap; i++)
        {
            foreach (Transform child in transform)
            {
                cubes.Clear();
                DestroyImmediate(child.gameObject);
            }
        }
    }

    [ContextMenu("Generate Room")]
    private void GenerateRoom()
    {
        
        
        DestroyRoom();
        
        

        for (int x = 0; x < x_length; x++)
        {
            for (int y = 0; y < y_length; y++)
            {
                matTxt.Append("0, ");
                for (int z = 0; z < z_length; z++)
                {
                    // I do NOT like this algorithm, there surely  is a better way
                    // but also, it just runs once so... maybe later?
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

    [ContextMenu("Generate floor")]
    private void GenerateFloor()
    {
        DestroyRoom();

        for (int x = 0; x < x_length; x++)
        {        
            for (int z = 0; z < z_length; z++)
            {
                GenerateCube(x + x_start, 0, z + z_start);
            }
        }

        GenerateTextFile();
    }

    [ContextMenu("Generate Text")]
    private void GenerateTextFile()
    {
        string path = @"./" + roomName + ".txt";

        Debug.Assert(roomName != null, "give the room a name!");
        using (FileStream fs = File.Create(path))

            if (File.Exists(path))
            {
                Debug.Log("file exsits");
            }

        matTxt.Clear();
        matTxt.Append("{\n");

        for(int i = 0; i < x_length; i++)
        {
            for(int j = 0; j < z_length; j++)
            {
                matTxt.Append("0, ");
            }
            matTxt.Append("},\n{");
        }

        File.WriteAllText(path, matTxt.ToString());

    }

    [ContextMenu("Make List")]
    private void MakeList()
    {
        if(cubes?.Count == 0)
        {
            foreach (Transform child in transform)
            {
                cubes.Add(child.gameObject);
            }
        }

        else
        {
            Debug.Log("Cube list already exist");
        }
    }

    //call this function from the Inspector(right click)
    [ContextMenu("Apply default material")]
    private void ApplyDefaultMaterial()
    {
        Renderer renderer;

        int matInd = 0;
        if(roomType == RoomType.background) matInd = 3;

        foreach (Transform child in transform)
        {
            renderer = child.gameObject.GetComponent<Renderer>();
            if(renderer != null || cubeMaterial.materials[matInd] != null)
            {
                renderer.sharedMaterial = cubeMaterial.materials[matInd];
            }
        }
    }

}
