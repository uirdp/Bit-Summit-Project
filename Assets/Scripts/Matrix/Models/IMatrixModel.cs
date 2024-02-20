using static DirectionSpace.Directions;
using System.Collections.Generic;
using UnityEngine;

//All static matrices should inherit this Interface

//MatrixInstant(Instance of a static matrix) should look for a dictionary
//through this Interface

public class Area
{

    private Vector2Int _initPos;
    private Vector2Int _initSize;

    public Area(Vector2Int pos, Vector2Int size, Direction[] man)
    {
        _initPos= pos;
        Pos = _initPos;

        _initSize = size;
        Size = _initSize;

        Manual = man;
        ManualIndex = 0;
    }

    public Vector2Int Pos { get; set; }
    public Vector2Int Size { get; set; }
    public Direction[] Manual { get; }

    public int ManualIndex { get; set; }

    public void ResetAreaStatus()
    {
        ManualIndex = 0;
        Pos = _initSize;
        Pos = _initPos;
    }


}
public interface IMatrixModel
{
    public int[,] InitMatrix { get; }
    public ref int[,] Matrix { get; }
    public ref Area[] RedAreas { get; }
    public ref Area[] GreenAreas { get; }

    //when it's hard to render simply by two for loops as x * y...
    //when the area cannot simply be represented as products of rows and columns
    public ref Area[] RewriteAreas { get; }

    public int NumOfRed { get; }
    public int NumOfGreen { get; }
    
}
