using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class SampleColorMatrixModel : IMatrixModel
{
    public static readonly string name = "sample";

    public int[,] matrix = new int[,]{
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

    public Point[] posOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(0,0)
    };

    public Point[] sizeOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(3, 3)
    };

    public static readonly Direction[] directions = new Direction[]
    {
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,

        Direction.down,
        Direction.down,
        Direction.down,
        Direction.down,
        Direction.down,
        Direction.down,
        Direction.down,
        
        Direction.left,
        Direction.left,
        Direction.left,
        Direction.left,
        Direction.left,
        Direction.left,
        Direction.left,

        Direction.up,
        Direction.up,
        Direction.up,
        Direction.up,
        Direction.up,
        Direction.up,
        Direction.up,
    };

    public ref int[,] Matrix => ref matrix;
    public List<int[,]> MovingMatrices => movingMatrices;
    public Direction[] Directions => directions;

    public ref Point[] PosOfMovingMatrices => ref posOfMovingMatrices;
    public ref Point[] SizeOfMovingMatrices => ref sizeOfMovingMatrices;

}
