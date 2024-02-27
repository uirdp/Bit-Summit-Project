using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class GardenSecondModel : IMatrixModel
{
    public static readonly string name = "garden-second";

    int[,] matrix =
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    };

    public const int numOfRedArea = 1;

    public static readonly Direction[][] directionsRed = new Direction[numOfRedArea][]
   {
        new Direction[]
        {
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,


            Direction.wait,
            Direction.wait,
            Direction.wait,

            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,


            Direction.wait,
            Direction.wait,
            Direction.wait,
        },
    };

    public Area[] redAreas = new Area[numOfRedArea]
    {
        new Area(new Vector2Int(5,0), new Vector2Int(1,20), directionsRed[0], 1),
    };


    public const int numOfGreenArea = 4;
    public static readonly Direction[][] directionsGreen = new Direction[1][]
    {
        new Direction[]
        {
            Direction.wait,
        }
    };

    public Area[] greenAreas = new Area[numOfGreenArea]
    {
        new Area(new Vector2Int(0, 15), new Vector2Int(2,2), directionsGreen[0], 1, false),
        new Area(new Vector2Int(4, 10), new Vector2Int(2,2), directionsGreen[0], 1, false),
        new Area(new Vector2Int(0, 5), new Vector2Int(2,2), directionsGreen[0], 1, false),
        new Area(new Vector2Int(4, 0), new Vector2Int(2,2), directionsGreen[0], 1, false),
    };

    public const int numOfRewriteArea = 0;
    public Area[] rewriteAreas = null;

    public int[,] InitMatrix => matrix;
    public ref int[,] Matrix => ref matrix;
    public ref Area[] RedAreas => ref redAreas;
    public ref Area[] GreenAreas => ref greenAreas;
    public ref Area[] RewriteAreas => ref rewriteAreas;

    public int NumOfRed => numOfRedArea;
    public int NumOfGreen => numOfGreenArea;

    public int NumOfRewriteArea => numOfGreenArea;
}
