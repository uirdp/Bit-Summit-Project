/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//later make abstract class instead of interface
public class SampleMatrixWithInterface : IColorMatrix
{
    public readonly string name = "sample";

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

    static readonly int[] directions = new int[] { 1, 2 };
    public MatrixManual manual; 

    private const int numOfMovingMatrices = 1;

    private Point[] posOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(0, 0)
    };

    private Point[] sizeOfMovingMatrices = new Point[numOfMovingMatrices]
    {
        new Point(0, 0)
    };

    //-------------------------------------Properties------------------------------------------------
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
        set { posOfMovingMatrices = value; }
    }

    public Point[] SizeOfMovingMatrices
    {
        get { return sizeOfMovingMatrices; }
        set { }
    }

    public void Init()
    {
        manual = new MatrixManual(directions);
    }
}
*/
