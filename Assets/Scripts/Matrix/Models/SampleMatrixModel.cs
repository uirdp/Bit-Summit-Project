using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class SampleColorMatrixModel : IMatrixModel
{
    public static readonly string name = "sample";

    public int[,] matrix = new int[,]{
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 2, 2, 2, 2, 0, 0, 0},
        {0, 0, 0, 2, 2, 2, 2, 0, 0, 0},
        {0, 0, 0, 2, 2, 2, 2, 0, 0, 0},
        {0, 0, 0, 2, 2, 2, 2, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };

    public const int numOfRedAreas = 1;

    public static readonly Direction[][] directionsRed = new Direction[numOfRedAreas][]
   {
        new Direction[]
        {
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,

            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,

            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,

            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
        }
    };


    public Area[] redAres = new Area[numOfRedAreas]
    {
        new Area(new Vector2Int(0,0), new Vector2Int(3, 3), directionsRed[0])
    };

    public const int numOfGreenArea = 1;

    public static readonly Direction[][] directionsGreen = new Direction[numOfRedAreas][]
   {
        new Direction[]
        {
            Direction.wait
        }
    };

    public Area[] greenAreas = new Area[numOfGreenArea]
    {
        new Area(new Vector2Int(3,3), new Vector2Int(4,4), directionsGreen[0])
    };


    public int[,] InitMatrix => matrix;
    public ref int[,] Matrix => ref matrix;
    public Area[] RedAreas => RedAreas;
    public Area[] GreenAreas => GreenAreas;

    public int NumOfRed => numOfRedAreas;
    public int NumOfGreen => numOfGreenArea;

}
