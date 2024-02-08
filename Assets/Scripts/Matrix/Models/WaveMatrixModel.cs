using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class WaveMatrixModel : IMatrixModel
{
    public static readonly string name = "wave";

    public int[,] matrix = new int[,]
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 1, 1, 0, 0, 0, 0, },
        {0, 0, 0, 0, 1, 1, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, }
    };

    public const int numOfMovingMatrices = 1;

    public static readonly int[,] movingMatrix =
    {
        {1, 1, },
        {1, 1, },
    };

    public static readonly List<int[,]> movingMatrices = new List<int[,]>
    {
        movingMatrix
    };

    public Point[] posOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(4,4)
    };

    public Point[] sizeOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(2, 2)
    };

    public static readonly Direction[] directions = new Direction[]
    {
       Direction.wave,
       Direction.wave,
       Direction.wave,
       Direction.wave,
       Direction.wave,
       Direction.erase
    };

    public int[,] InitMatrix => matrix;
    public ref int[,] Matrix => ref matrix;
    public List<int[,]> MovingMatrices => movingMatrices;
    public Direction[] Directions => directions;

    public ref Point[] PosOfMovingMatrices => ref posOfMovingMatrices;
    public ref Point[] SizeOfMovingMatrices => ref sizeOfMovingMatrices;
}
