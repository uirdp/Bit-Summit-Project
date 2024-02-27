using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class GardenFirstModel : IMatrixModel
{
    public static readonly string name = "gardenFisrt";

    int[,] matrix =
    {
        {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    };

    public const int numOfRedArea = 2;

    public static readonly Direction[][] directionsRed = new Direction[numOfRedArea][]
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
            Direction.up,
            Direction.up,
            Direction.up,
        },

        new Direction[]
        {
            Direction.left,
            Direction.left,
            Direction.left,
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
            Direction.up,
            Direction.up,
            Direction.up,

            Direction.right,
            Direction.right,
            Direction.right,
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
            Direction.down,
            Direction.down,
            Direction.down,

        }
    };

    public Area[] redAreas = new Area[numOfRedArea]
    {
        new Area(new Vector2Int(0,0), new Vector2Int(6, 6), directionsRed[0], 1),
        new Area(new Vector2Int(10,10), new Vector2Int(6, 6), directionsRed[1], 1, false)
    }; 
    
    
    public const int numOfGreenArea = 3;
    public static readonly Direction[][] directionsGreen = new Direction[1][]
    {
        new Direction[]
        {
            Direction.wait
        }
    };

    public Area[] greenAreas = new Area[numOfGreenArea]
    {
        new Area(new Vector2Int(6,6), new Vector2Int(4,4), directionsGreen[0], 1),
        new Area(new Vector2Int(12,0), new Vector2Int(4, 4), directionsGreen[0], 1, false),
        new Area(new Vector2Int(0,12), new Vector2Int(4, 4), directionsGreen[0], 1, false)
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
