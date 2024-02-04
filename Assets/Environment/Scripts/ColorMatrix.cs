using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IColorMatrix
{
    public int[,] colorMatrix { get; set; }

    public int numOfMovingMatrices { get; set; }    

    public Point[] posOfMovingMatrices { get; set; }
    public Point[] sizeOfMovingMatrices { get; set; }

}
