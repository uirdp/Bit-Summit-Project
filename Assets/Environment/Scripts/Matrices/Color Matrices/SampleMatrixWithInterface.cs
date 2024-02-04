using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMatrixWithInterface : IColorMatrix
{
    private readonly int[,] matrix = new int[,]{
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

    private const int numOfMovingMatrices = 1;

    private readonly Point[] posOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(0, 0)
    };

    private readonly Point[] sizeOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(0, 0)
    };

    public int[,] ColorMatrix
    {
        get { return matrix; }
        set { }
    }

    public int NumOfMovingMatrices
    {
        get { return numOfMovingMatrices;  }
        set { }
    }

    public Point[] PosOfMovingMatrices
    {
        get { return posOfMovingMatrices; }
        set { }
    }

    public Point[] SizeOfMovingMatrices
    {
        get { return sizeOfMovingMatrices; }
        set { }
    }

}
