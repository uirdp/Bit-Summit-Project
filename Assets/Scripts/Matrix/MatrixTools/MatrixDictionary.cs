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
            { "switch", new SampleSwitchModel() },
            { "motorway", new SampleMotorWayModel() },
            { "garden-first", new GardenFirstModel() },
            { "border", new BorderModel() },
            { "garden-second", new GardenSecondModel() },
            { "garden-last", new GardenLast() },
        };

    public IMatrixModel ReturnMatrix(string targetName)
    {
        return matrixDictionary[targetName];
    }
}
