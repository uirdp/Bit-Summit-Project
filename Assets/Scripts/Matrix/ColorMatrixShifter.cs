using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static DirectionSpace.Directions;

public class ColorMatrixShifter : MonoBehaviour
{
    //public SampleColorMatrix colorMatrix;
    public CubeSignalManager signalManager;
    public IMatrixModel colorMatrix;

    public string matrixName = "sample";
    private MatrixDictionary _dict;

    private MatrixManual manual;

    public float interval = 0.5f;

    private Point initPos;
    private Point initSize;

    public bool useReset = true;
    private int[,] initMatrix = null;
    //which -> which Matrix to move, should be renamed

    //----------------------------shift method----------------------------------------------------------
    public void ShiftMatrixToRight(int which)
    {
        //get right top element of submatrix, because it's swapped first
        int r = colorMatrix.PosOfMovingMatrices[which].x +
                    colorMatrix.SizeOfMovingMatrices[which].x;

        int y = colorMatrix.PosOfMovingMatrices[which].y;

        for (int i = 0; i < colorMatrix.SizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.SizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.Matrix[r - 1 - i, y + j];
                colorMatrix.Matrix[r - 1 - i, y + j] = colorMatrix.Matrix[r - i,y + j];
                colorMatrix.Matrix[r - i, y + j] = tmp;
            }
        }

        colorMatrix.PosOfMovingMatrices[which].x++;
    }



    public void ShiftMatrixToLeft(int which)
    {
        // Get left top element of submatrix, because it's swapped first
        int l = colorMatrix.PosOfMovingMatrices[which].x;

        int y = colorMatrix.PosOfMovingMatrices[which].y;

        for (int i = 0; i < colorMatrix.SizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.SizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.Matrix[l + i, y + j];
                colorMatrix.Matrix[l + i, y + j] = colorMatrix.Matrix[l + i - 1, y + j];
                colorMatrix.Matrix[l + i - 1, y + j] = tmp;
            }
        }

        colorMatrix.PosOfMovingMatrices[which].x--;
    }

    public void ShiftMatrixToUp(int which)
    {
        // Get top left element of submatrix, because it's swapped first
        int t = colorMatrix.PosOfMovingMatrices[which].y;
        int x = colorMatrix.PosOfMovingMatrices[which].x;

        for (int i = 0; i < colorMatrix.SizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.SizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.Matrix[x + i, t + j];
                colorMatrix.Matrix[x + i, t + j] = colorMatrix.Matrix[x + i, t + j - 1];
                colorMatrix.Matrix[x + i, t + j - 1] = tmp;
            }
        }

        colorMatrix.PosOfMovingMatrices[which].y--;
    }

    public void ShiftMatrixToDown(int which)
    {
        // Get bottom left element of submatrix, because it's swapped first
        int b = colorMatrix.PosOfMovingMatrices[which].y +
                    colorMatrix.SizeOfMovingMatrices[which].y;
        
        int x = colorMatrix.PosOfMovingMatrices[which].x;

        for (int i = 0; i < colorMatrix.SizeOfMovingMatrices[which].x; i++)
        {
            for (int j = 0; j < colorMatrix.SizeOfMovingMatrices[which].y; j++)
            {
                int tmp = colorMatrix.Matrix[x + i, b - 1 - j];
                colorMatrix.Matrix[x + i, b - 1 - j] = colorMatrix.Matrix[x + i, b - j];
                colorMatrix.Matrix[x + i, b - j] = tmp;
            }
        }


        colorMatrix.PosOfMovingMatrices[which].y++;
    }

    public void StretchMatrixToUp(int which)
    {

    }

    public void FormWaveMatrix(int which)
    {
        ref Point sz = ref colorMatrix.SizeOfMovingMatrices[which];

        ref Point pos = ref colorMatrix.PosOfMovingMatrices[which];
        

        for (int i = 0; i < sz.x; i++)
        {
            for( int j = 0; j < sz.y; j++)
            {
                if(i == 0 || j == 0 || i == sz.x - 1 || j == sz.y - 1)
                {
                    colorMatrix.Matrix[pos.x + i, pos.y + j] = 1;
                }

                else
                {
                    colorMatrix.Matrix[pos.x + i, pos.y + j] = 0;
                }
            }
            
        }
        //need to reset size
        sz.x += 2;
        sz.y += 2;

        Debug.Log(colorMatrix.SizeOfMovingMatrices[which].x);

        pos.x--;
        pos.y--;
    }

    public void EraseMatrix()
    {
        int xsz = colorMatrix.Matrix.GetLength(0);
        int ysz = colorMatrix.Matrix.GetLength(1);

        for(int i = 0; i < xsz; i++)
        {
            for(int j = 0; j < ysz; j++)
            {
                colorMatrix.Matrix[i, j] = 0;
            }
        }
    }

    //----------------------------end of shift method----------------------------------------------------------

    private void ResetMatrix()
    {
        colorMatrix.PosOfMovingMatrices[0] = initPos;
        colorMatrix.SizeOfMovingMatrices[0] = initSize;

    }
    public IEnumerator ShiftMatrix()
    {
        Direction dir = manual.GetDirection();

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
            case Direction.wave:
                FormWaveMatrix(0); break;
            case Direction.erase:
                EraseMatrix(); break;
        }


        manual.GotoNextStep();
        if (manual.index >= manual.shiftDirections.Length)
        {
            manual.BackToTheFirstStep();
            ResetMatrix();
        }

        yield return new WaitForSeconds(interval);

        SendSignal();

        StartCoroutine(ShiftMatrix());
    }

    public void SendSignal()
    {
        //TODO: updates only where the change happend
        signalManager.ChangeCubeMaterials(ref colorMatrix.Matrix);
    }

    public void Init()
    {
        //Get a matrix to shift from the dictionary
        _dict = new MatrixDictionary();
        colorMatrix = _dict.ReturnMatrix(matrixName);

        //Get a manual for shifting the matrix
        manual = new MatrixManual(colorMatrix.Directions);

        //need to be a for loop if more than one moving matrices
        initPos = colorMatrix.PosOfMovingMatrices[0];
        initSize = colorMatrix.SizeOfMovingMatrices[0];

        if (useReset) initMatrix = colorMatrix.InitMatrix;

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
