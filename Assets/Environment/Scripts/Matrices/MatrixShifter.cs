using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixShifter : MonoBehaviour
{

    //(matrix to shift, i of (i, j), amount of rows, column)
    public static void RightShiftMatrix(ref int[,] matrix,ref int start, int rows, int columns)
    {
        int r = start + rows;
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Debug.Log(r - i);
                int tmp = matrix[r - 1 - i,j];
                matrix[r - 1 - i, j] = matrix[r - i,j];
                matrix[r - i,j] = tmp;
            }
        }

        start++;
    }

 
}
