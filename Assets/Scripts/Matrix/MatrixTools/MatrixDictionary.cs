using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixDictionary
{
    private static Dictionary<string, IMatrixModel>
        matrixDictionary = new Dictionary<string, IMatrixModel>()
        {
            { "sample", new SampleColorMatrixModel() },
            { "corridor", new SampleCorridor() },
            {"switch", new SampleSwitchModel() }
        };

    public IMatrixModel ReturnMatrix(string targetName)
    {
        return matrixDictionary[targetName];
    }
}
