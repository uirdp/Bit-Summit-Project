using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Use group matricies when group members are adjacent to each other
public class CubeColorMatrix
{
    public int[,] colorMatrix;
    public int[,] groupMatrix; //part of matrix which moves

    public CubeMatrixGenerator matrices = null;

    public int groupMatSizeX = 0;
    public int groupMatSizeY = 0;

    [Tooltip("initial point of moving matrix")]
    [SerializeField]
    private int groupMatPosX = 0;

    [SerializeField] 
    private int groupMatPosY = 0;

    //static matrix should be inserted to colorMatrix
    //move left(), right(), up(), down() diag()...
    //Do I need a real matrix? think just inx is enough
    //or perhaps, create a actual matrix and update 
    //every element

    //as an idea but don't try to make it too complicated

    /*private void CreateColorMatrix()
     *{
     *  for(int i = 0; i < colorMatSizeX; i++)
     *   {
     *       for( int j = 0; j < colorMatSizeY; j++)
     *       {
     *           colorMatrix[i, j] = 0;
     *       }
     *   }
     }*/

    private void CreateGroupMatrix()
    {
        for (int i = 0; i < groupMatSizeX; i++)
        {
            for (int j = 0; j < groupMatSizeY; j++)
            {
                groupMatrix[i, j] = 1;
            }
        }
    }

    private void MergeGroupMatrixToColorMatrix()
    {
        for(int i = 0; i < groupMatrix.GetLength(0); i++)
        {
            for(int j = 0; j < groupMatrix.GetLength(1); j++)
            {
                colorMatrix[i + groupMatPosX, j + groupMatPosY] = groupMatrix[i, j];
            }
        }
    }

    private void InitializeMatrix()
    {
        colorMatrix = matrices?.colorMatrix;
    }

}
