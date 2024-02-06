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

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[r - 1 - i, j];
                colorMatrix.matrix[r - 1 - i, j] = colorMatrix.matrix[r - i, j];
                colorMatrix.matrix[r - i, j] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].x++;
    }



    public void ShiftMatrixToLeft(int which)
    {
        // Get left top element of submatrix, because it's swapped first
        int l = colorMatrix.posOfMovingMatrices[which].x;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[l + i + 1, j];
                colorMatrix.matrix[l + i + 1, j] = colorMatrix.matrix[l + i, j];
                colorMatrix.matrix[l + i, j] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].x--;
    }

    public void ShiftMatrixToUp(int which)
    {
        // Get top left element of submatrix, because it's swapped first
        int t = colorMatrix.posOfMovingMatrices[which].y;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[i, t + j + 1];
                colorMatrix.matrix[i, t + j + 1] = colorMatrix.matrix[i, t + j];
                colorMatrix.matrix[i, t + j] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].y--;
    }

    public void ShiftMatrixToDown(int which)
    {
        // Get bottom left element of submatrix, because it's swapped first
        int b = colorMatrix.posOfMovingMatrices[which].y +
                    colorMatrix.sizeOfMovingMatrices[which].y;

        for (int i = 0; i < colorMatrix.sizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.sizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.matrix[i, b - 1 - j];
                colorMatrix.matrix[i, b - 1 - j] = colorMatrix.matrix[i, b - j];
                colorMatrix.matrix[i, b - j] = tmp;
            }
        }

        colorMatrix.posOfMovingMatrices[which].y++;
    }

    public IEnumerator ShiftMatrix()
    {
        Direction dir = colorMatrix.manual.GetDirection();

        switch(dir)
        {
            case Direction.right:
                ShiftMatrixToRight(0); break;
        }

        
        colorMatrix.manual.GotoNextStep();

        yield return new WaitForSeconds(1.5f);

        SendSignal();
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
