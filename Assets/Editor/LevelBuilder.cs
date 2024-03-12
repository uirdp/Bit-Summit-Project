using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;


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

    public static string GetDirectionArrayStatement(string num)
	{
        return "public static readonly Direction[][] directionsRed = new Direction[" + num + "][]";
	}

    public static string GetDirectionStatements(string dir)
	{
        string st = "new Direction[]\n{" +
                    dir + "\n},";

        return st;                    
	}
}


public class LevelBuilder : EditorWindow
{
    private int x_start = 0;
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

    [MenuItem("Editor Extention/Level Builder", false, 1)]
    private static void ShowWindow()
	{
        LevelBuilder window = GetWindow<LevelBuilder>();

        window.titleContent = new GUIContent("Sample Window");
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

}
