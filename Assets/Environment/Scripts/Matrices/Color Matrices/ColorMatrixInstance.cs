using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class instantiate a colorMatrix to manipulate
public class ColorMatrixInstance : MonoBehaviour
{
    [Tooltip("Name of the matrix you are intending to use")]
    public string matrixName = "sample";
    private MatrixDictionary dict;

    IMatrixModel colorMatrix;
    
    private void GetMatrix()
    {
        dict = new MatrixDictionary();
        colorMatrix = dict.ReturnMatrix(matrixName);

        if (colorMatrix == null) Debug.Log("unable to fetch matrix");
    }

    private void Awake()
    {
        GetMatrix();
    }
}
