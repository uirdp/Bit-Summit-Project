using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class SampleMotorWayModel : IMatrixModel
{

    public static readonly string name = "motorway";

    public int[,] matrix = new int[,]
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },

    };

    public const int numOfRedArea = 1;

    public static readonly Direction[][] directionsRed = new Direction[1][]
   {
        new Direction[]
        {
            Direction.allRed
        },
    };


    public Area[] redAreas = new Area[numOfRedArea]
    {
        new Area(new Vector2Int(0, 0), new Vector2Int(0,0), directionsRed[0],0)
    };

    public const int numOfGreenArea = 12;

    public static readonly Direction[][] directionGreen = new Direction[2][]
    {
        new Direction[]
        {

            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
            Direction.left,
        },

        new Direction[]
        {
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,
            Direction.right,

        },

    };

    public Area[] greenAreas = new Area[numOfGreenArea]
    {
        new Area(new Vector2Int(2,21), new Vector2Int(2, 2), directionGreen[0], 0),
        new Area(new Vector2Int(5,21), new Vector2Int(2, 2), directionGreen[0], 0),

        new Area(new Vector2Int(2,17), new Vector2Int(2, 2), directionGreen[0], 0),
        new Area(new Vector2Int(5,17), new Vector2Int(2, 2), directionGreen[0], 0),

        new Area(new Vector2Int(2,13), new Vector2Int(2, 2), directionGreen[0], 0),
        new Area(new Vector2Int(5,13), new Vector2Int(2, 2), directionGreen[0], 0),

        new Area(new Vector2Int(2,9), new Vector2Int(2, 2), directionGreen[0], 0),
        new Area(new Vector2Int(5,9), new Vector2Int(2, 2), directionGreen[0], 0),

        new Area(new Vector2Int(2,5), new Vector2Int(2, 2), directionGreen[0], 0),
        new Area(new Vector2Int(5,5), new Vector2Int(2, 2), directionGreen[0], 0),

        new Area(new Vector2Int(2,1), new Vector2Int(2, 2), directionGreen[0], 0),
        new Area(new Vector2Int(5,1), new Vector2Int(2, 2), directionGreen[0], 0),


    };

    public const int numOfRewriteArea = 0;
    public Area[] rewriteArea = null;

    public int[,] InitMatrix { get; }
    public ref int[,] Matrix => ref matrix;
    public ref Area[] RedAreas => ref redAreas;
    public ref Area[] GreenAreas => ref greenAreas;
    public ref Area[] RewriteAreas => ref rewriteArea;

    public int NumOfRed => numOfRedArea;
    public int NumOfGreen => numOfGreenArea;
    public int NumOfRewriteArea => numOfRewriteArea;
}
