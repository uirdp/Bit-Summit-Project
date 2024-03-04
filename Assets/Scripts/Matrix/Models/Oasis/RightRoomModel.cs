using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class OasisRightModel : IMatrixModel
{



    public static readonly string name = "oasis-rightroom";

    int[,] matrix =
    {
        {0, 0, 0, },
        {0, 0, 0, },
        {0, 0, 0, },

    };

    public const int numOfRedArea = 1;

    public static readonly Direction[][] directionsRed = new Direction[numOfRedArea][]
   {
        new Direction[]
        {
            Direction.wait
        },
    };

    public Area[] redAreas = new Area[numOfRedArea]
    {
        new Area(new Vector2Int(0,0), new Vector2Int(3,3), directionsRed[0], 1),
    };


    public const int numOfGreenArea = 1;
    public static readonly Direction[][] directionsGreen = new Direction[numOfGreenArea][]
    {
        new Direction[]
        {
            Direction.wait
        }
    };


    public Area[] greenAreas = new Area[numOfGreenArea]
    {
        new Area(new Vector2Int(0,0), new Vector2Int(3,3), directionsGreen[0], 1, false)
    };
        
    public const int numOfRewriteArea = 0;
    public Area[] rewriteAreas;

    public int[,] InitMatrix => matrix;
    public ref int[,] Matrix => ref matrix;
    public ref Area[] RedAreas => ref redAreas;
    public ref Area[] GreenAreas => ref greenAreas;
    public ref Area[] RewriteAreas => ref rewriteAreas;

    public int NumOfRed => numOfRedArea;
    public int NumOfGreen => numOfGreenArea;

    public int NumOfRewriteArea => numOfGreenArea;
}
