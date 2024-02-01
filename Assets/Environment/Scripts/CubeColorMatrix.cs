using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorMatrix : MonoBehaviour
{
    public int[,] colorMatrix;

    //static matrix should be inserted to colorMatrix
    //move left(), right(), up(), down() diag()...
    //Do I need a real matrix? think just inx is enough
    //or perhaps, create a actual matrix and update 
    //every element

    private void GetColorMatrixFromCubeMatrixGenerator(int[,] mat)
    {
        colorMatrix = mat;
    }

    private void CreateColorMatrix(int rows, int columns)
    {
        for(int i = 0; i < rows; i++)
        {
            for( int j = 0; j < columns; j++)
            {
                colorMatrix[i, j] = 0;
            }
        }
    }
}
