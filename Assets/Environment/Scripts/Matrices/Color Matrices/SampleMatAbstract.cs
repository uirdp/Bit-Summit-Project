using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Direction.Dir;

public static class SampleColorMatrixModel
{
    public static readonly int[,] matrix = new int[,]{
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };

    public const int numOfMovingMatrices = 1;
    public static readonly int[,] movingMatrix = new int[,]
    {
        {1, 1, 1 },
        {1, 1, 1 },
        {1, 1, 1 },
    };

    public static readonly int[] manual = new int[]
    {
        (int)directions.right,
        (int)directions.right,
        (int)directions.right,
        (int)directions.right,
        (int)directions.right,
        (int)directions.right,
        (int)directions.right,
    };

}

public class SampleMatAbstract : ColorMatrixBase
{
    private string _name = "sample";

    public override void Init()
    {
        name = _name;
        matrix = SampleColorMatrixModel.matrix;
        manual = new MatrixManual(SampleColorMatrixModel.manual);

        posOfMovingMatrices = new Point[SampleColorMatrixModel.numOfMovingMatrices]
        {
             new Point(0, 0)
        };

        sizeOfMovingMatrices = new Point[SampleColorMatrixModel.numOfMovingMatrices]
        {
            new Point(3, 3)
        };
    }
}
