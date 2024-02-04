using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorMatrixBase
{
    public  string name;
    private int numOfMovingMatrices = 1;

    public int[,] matrix;
    public MatrixManual manual;

    public Point[] posOfMovingMatrices;
    public Point[] sizeOfMovingMatrices;
    public abstract void Init();
   
}
