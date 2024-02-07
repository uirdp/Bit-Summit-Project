using System.Collections;
using System.Collections.Generic;
using System;
using TMPro.EditorUtilities;
using UnityEngine;
using static DirectionSpace.Directions;


//Use group matricies when group members are adjacent to each other
public class ColorMatrixShifter : MonoBehaviour
{
    //public SampleColorMatrix colorMatrix;
    public CubeSignalManager signalManager;
    public SampleMatAbstract colorMatrix;

    //which -> which Matrix to move, should be renamed
    public void ShiftMatrixToRight(int which)
    {
        //get right top element of submatrix, because it's swapped first
        int r = colorMatrix.posOfMovingMatrices[which].x +
                    colorMatrix.sizeOfMovingMatrices[which].x;

        int y = colorMatrix.posOfMovingMatrices[which].y;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[r - 1 - i, y + j];
                colorMatrix.matrix[r - 1 - i, y + j] = colorMatrix.matrix[r - i,y + j];
                colorMatrix.matrix[r - i, y + j] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].x++;
    }



    public void ShiftMatrixToLeft(int which)
    {
        // Get left top element of submatrix, because it's swapped first
        int l = colorMatrix.posOfMovingMatrices[which].x;

        int y = colorMatrix.posOfMovingMatrices[which].y;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[l + i, y + j];
                colorMatrix.matrix[l + i, y + j] = colorMatrix.matrix[l + i - 1, y + j];
                colorMatrix.matrix[l + i - 1, y + j] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].x--;
    }

    public void ShiftMatrixToUp(int which)
    {
        // Get top left element of submatrix, because it's swapped first
        int t = colorMatrix.posOfMovingMatrices[which].y;
        int x = colorMatrix.posOfMovingMatrices[which].x;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                Debug.Log("(i, j) = " + (x + i) + " , " + (t + j));
                int tmp = colorMatrix.matrix[x + i, t + j];
                colorMatrix.matrix[x + i, t + j] = colorMatrix.matrix[x + i, t + j - 1];
                colorMatrix.matrix[x + i, t + j - 1] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].y--;
    }

    public void ShiftMatrixToDown(int which)
    {
        // Get bottom left element of submatrix, because it's swapped first
        int b = colorMatrix.posOfMovingMatrices[which].y +
                    colorMatrix.sizeOfMovingMatrices[which].y;
        
        int x = colorMatrix.posOfMovingMatrices[which].x;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[x + i, b - 1 - j];
                colorMatrix.matrix[x + i, b - 1 - j] = colorMatrix.matrix[x + i, b - j];
                colorMatrix.matrix[x + i, b - j] = tmp;
            }
        }


        colorMatrix.posOfMovingMatrices[which].y++;
    }

    public IEnumerator ShiftMatrix()
    {
        Direction dir = colorMatrix.manual.GetDirection();

        Debug.Log(dir);

        switch(dir)
        {
            case Direction.right:
                ShiftMatrixToRight(0); break;
            case Direction.left:
                ShiftMatrixToLeft(0);  break;
            case Direction.up:
                ShiftMatrixToUp(0);    break;
            case Direction.down:
                ShiftMatrixToDown(0);  break;
        }


        colorMatrix.manual.GotoNextStep();

        yield return new WaitForSeconds(0.5f);

        SendSignal();

        /*for (int i = 0; i < colorMatrix.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < colorMatrix.matrix.GetLength(1); j++)
            {
                Debug.Log("(" + i + "," + j + ") = " + colorMatrix.matrix[i, j]);
            }
        }*/

        StartCoroutine(ShiftMatrix());
    }

    public void SendSignal()
    {
        signalManager.ChangeCubeMaterials(ref colorMatrix.matrix);
    }

    public void Init()
    {
        colorMatrix= new SampleMatAbstract();
    }
    public void Start()
    {
        StartCoroutine(ShiftMatrix());
    }

    public void Awake()
    {
        Init();
    }

}
