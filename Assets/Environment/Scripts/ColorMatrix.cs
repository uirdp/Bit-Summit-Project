using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IColorMatrix
{
    int[,] ColorMatrix { get; set; }

    int NumOfMovingMatrices { get; set; }    

    Point[] PosOfMovingMatrices { get; set; }
    Point[] SizeOfMovingMatrices { get; set; }

}
