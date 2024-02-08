using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixDictionary
{
    private static Dictionary<string, IMatrixModel>
        matrixDictionary = new Dictionary<string, IMatrixModel>()
        {
            { "sample", new SampleColorMatrixModel() },
            { "wave",  new WaveMatrixModel() }
        };

    public IMatrixModel ReturnMatrix(string targetName)
    {
        return matrixDictionary[targetName];
    }
}
