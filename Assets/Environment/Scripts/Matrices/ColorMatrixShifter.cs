using System.Collections;
using System.Collections.Generic;
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
    public void RightShiftMatrix(int which)
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

    public IEnumerator ShiftMatrix()
    {
        Direction dir = colorMatrix.manual.GetDirection();

        switch(dir)
        {
            case Direction.right:
                RightShiftMatrix(0); break;
        }

        SendSignal();
        colorMatrix.manual.GotoNextStep();

        yield return new WaitForSeconds(1.5f);

        dir = colorMatrix.manual.GetDirection();
        switch (dir)
        {
            case Direction.right:
                RightShiftMatrix(0); break;
        }

        SendSignal();
        colorMatrix.manual.GotoNextStep();

        yield return new WaitForSeconds(1.5f);

        dir = colorMatrix.manual.GetDirection();
        switch (dir)
        {
            case Direction.right:
                RightShiftMatrix(0); break;
        }
        SendSignal();

        yield return new WaitForSeconds(1.5f);

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
