using static DirectionSpace.Directions;
using System.Collections.Generic;
using UnityEngine;

//All static matrices should inherit this Interface

//MatrixInstant(Instance of a static matrix) should look for a dictionary
//through this Interface

public struct Area
{
    public Area(Vector2Int pos, Vector2Int size, Direction[] man)
    {
        Pos = pos;
        Size = size;
        Manual = man;
    }

    public Vector2Int Pos { get; set; }
    public Vector2Int Size { get; set; }
    public Direction[] Manual { get; }

}
public interface IMatrixModel
{
    public int[,] InitMatrix { get; }
    public ref int[,] Matrix { get; }
    public Area[] RedAreas { get; }
    public Area[] GreenAreas { get; }

    public int NumOfRed { get; }
    public int NumOfGreen { get; }
    
}
