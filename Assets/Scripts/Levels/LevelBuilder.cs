using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public enum RoomType
{
    level,
    background,
    border
}

public static class MatrixModelTextTemplate
{
	public const string UsingStatements = "using System.Collections;\n" +
                                         "using System.Collections.Generic;\n" +
                                         "using UnityEngine;\n" +
                                         "using static DirectionSpace.Directions;\n";

    //TODO: Rename all those "Get" to something else
    public static string GetDirectiveStatements()
	{
        string st = "using System.Collections;\n" +
                    "using System.Collections.Generic;\n" +
                    "using UnityEngine;\n" +
                    "using static DirectionSpace.Directions;\n";

        return st;
    }

    //<param name="matrixClassName">goes to be the class name in the file, cap first letter<param>
    public static string GetClassDefinitionText(string matrixClassName)
	{
        string st = "public class " +
                     matrixClassName +
                     " : IMatrixModel\n";

        return st;
    }

    public static string GetRoomName(string roomName)
	{
        string st = "public static readonly string name = " + roomName + "\n";

        return st;
    }

    public static string GetMatrixDefinitionText(string matrixText)
	{
        string st = "int[,] = {\n" +
                    matrixText +
                    "};\n";

        return st;
	}

    public static string GetNumOfRedColourText(string num)
	{
        return "public const int numOfRedArea = " + num;
	}

    public static string GetDirectionStatement(string num)
	{
        string st = "public static readonly Direction[][] directionsRed = new Direction[numOfRedArea][]";
        return st;
	}
}

//this code is a mess, sorry 
public class LevelBuilder : MonoBehaviour
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

    public bool makeMatText = true;
    public StringBuilder matTxt = new StringBuilder();

    public string tag = "default";

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
                DestroyImmediate(child.gameObject);
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
        string path = @"./Assets/Scripts/Matrix/Models/Auto" + roomName + ".txt";

        if (!string.IsNullOrEmpty(roomName))
        {
            using (FileStream fs = File.Create(path))

                if (File.Exists(path))
                {
                    Debug.Log("file exsits");
                }

            matTxt.Clear();
            matTxt.Append("{\n");

            for (int i = 0; i < x_length; i++)
            {
                for (int j = 0; j < z_length; j++)
                {
                    matTxt.Append("0, ");
                }
                matTxt.Append("},\n{");
            }

            File.WriteAllText(path, matTxt.ToString());
        }

        else
        {
            Debug.Log("enter the name");
        }

    }

    //call this function from the Inspector(right click)
    [ContextMenu("Apply default material")]
    //in the future plz fix this mess
    private void ApplyDefaultMaterial()
    {
        Renderer renderer;

        int matInd = 0;
        if (roomType == RoomType.background) matInd = 3;
        if (roomType == RoomType.border)
        {
            matInd = 1;
            tag = "Dangerous";
        }

        foreach (Transform child in transform)
        {
            child.gameObject.tag = tag;
            renderer = child.gameObject.GetComponent<Renderer>();
            if (renderer != null || cubeMaterial.materials[matInd] != null)
            {
                renderer.sharedMaterial = cubeMaterial.materials[matInd];
            }
        }
    }

}
