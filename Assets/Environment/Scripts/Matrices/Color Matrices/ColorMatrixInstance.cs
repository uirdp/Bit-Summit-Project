using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class instantiate a colorMatrix to manipulate
public class ColorMatrixInstance : MonoBehaviour
{
    [Tooltip("Name of the matrix you are intending to use")]
    public string matrixName = "sample";
    private MatrixDictionary _dict;

    public IMatrixModel _colorMatrix;
    
    private void GetMatrix()
    {
        _dict = new MatrixDictionary();
        _colorMatrix = _dict.ReturnMatrix(matrixName);

        if (_colorMatrix == null) Debug.Log("unable to fetch matrix");
    }

    private void Awake()
    {
        GetMatrix();
    }
}
