using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class OasisLeftModel : IMatrixModel
{
    public static readonly string name = "oasis-leftroom";

    int[,] matrix =
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, },
    };

    public const int numOfRedArea = 1;

    public static readonly Direction[][] directionsRed = new Direction[numOfRedArea][]
   {
        new Direction[]
        {

            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,
            Direction.down,

            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,

            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
            Direction.up,
         
          
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
        },
    };

    public Area[] redAreas = new Area[numOfRedArea]
    {
        new Area(new Vector2Int(0,0), new Vector2Int(3, 3), directionsRed[0], 1),
    };


    public const int numOfGreenArea = 0;
    public static readonly Direction[][] directionsGreen = new Direction[numOfGreenArea][]
    {

    };

    public Area[] greenAreas = new Area[numOfGreenArea]
    {
       
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
