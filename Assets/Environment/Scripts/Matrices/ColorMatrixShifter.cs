using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;


//Use group matricies when group members are adjacent to each other
public class ColorMatrixShifter : MonoBehaviour 
{
    public SampleColorMatrix colorMatrix;
    public CubeSignalManager signalManager;
    public IEnumerator ShiftMatrix()
    {
        yield return new WaitForSeconds(0.5f);
        SendSignal();
        yield return new WaitForSeconds(2.5f);

        Debug.Log("second");
        MatrixShifter.RightShiftMatrix(ref colorMatrix.matrix, ref colorMatrix.posOfMovingMatrixX,
                                        colorMatrix.sizeOfMovingMatrixX,
                                        colorMatrix.sizeOfMovingMatrixY);
        SendSignal();
        yield return new WaitForSeconds(0.5f);

        MatrixShifter.RightShiftMatrix(ref colorMatrix.matrix, ref colorMatrix.posOfMovingMatrixX,
                                        colorMatrix.sizeOfMovingMatrixX, 
                                        colorMatrix.sizeOfMovingMatrixY);
        SendSignal();

        yield return new WaitForSeconds(0.5f);

        MatrixShifter.RightShiftMatrix(ref colorMatrix.matrix, ref colorMatrix.posOfMovingMatrixX,
                                        colorMatrix.sizeOfMovingMatrixX,
                                        colorMatrix.sizeOfMovingMatrixY);
        SendSignal();

    }
    
    public void SendSignal()
    {
        signalManager.ChangeCubeMaterials(ref colorMatrix.matrix);
    }

    public void Start()
    {
        StartCoroutine(ShiftMatrix());
    }
}
