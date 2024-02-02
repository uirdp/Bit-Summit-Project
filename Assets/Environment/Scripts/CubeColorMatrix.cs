using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Use color matricies when group members are adjacent to each other
public class CubeColorMatrix : MonoBehaviour
{
    public int[,] colorMatrix;
    public int[,] groupMatrix;

    //static matrix should be inserted to colorMatrix
    //move left(), right(), up(), down() diag()...
    //Do I need a real matrix? think just inx is enough
    //or perhaps, create a actual matrix and update 
    //every element

    //as an idea but don't try to make it so complicated

    //copy a matrix and returns, put it in a avr
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

    private void CreateGroupMatrix(int rows, int columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                groupMatrix[i, j] = 0;
            }
        }
    }

    private void MergeGroupMatrixToColorMatrix(int rowStart, int colStart)
    {
        for(int i = 0; i < groupMatrix.GetLength(0); i++)
        {
            for(int j = 0; j < groupMatrix.GetLength(1); j++)
            {
                colorMatrix[i + rowStart, j + colStart] = groupMatrix[i, j];
            }
        }
    }
}
