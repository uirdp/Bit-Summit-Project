using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class SampleColorMatrixModel : IMatrixModel
{
    public static readonly string name = "sample";

    public static readonly int[,] matrix = new int[,]{
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };

    public const int numOfMovingMatrices = 1;

    public static readonly int[,] movingMatrix = new int[,]
    {
        {1, 1, 1 },
        {1, 1, 1 },
        {1, 1, 1 },
    };

    public static readonly List<int[,]> movingMatrices = new List<int[,]>
    {
        movingMatrix
    };

    public static readonly Direction[] manual = new Direction[]
    {
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
    };

    public int[,] Matrix => matrix;
    public List<int[,]> MovingMatrices => movingMatrices;
    public Direction[] Manual => manual;

}
