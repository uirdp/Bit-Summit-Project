using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixDictionary
{
    private static Dictionary<IReadOnlyMatrixModel, string>
        matrixDictionary = new Dictionary<IReadOnlyMatrixModel, string>()
        {
            { new SampleColorMatrixModel() , "sample" }
        };
}
