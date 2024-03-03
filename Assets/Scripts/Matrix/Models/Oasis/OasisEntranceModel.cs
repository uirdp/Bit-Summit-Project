using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class OasisEntranceModel : IMatrixModel
{

    public static readonly string name = "oasis-entrance";

    int[,] matrix =
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
    };

    public const int numOfRedArea = 10;

    public static readonly Direction[][] directionsRed = new Direction[2][]
   {
        new Direction[]
        {
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
        new Area(new Vector2Int(2,0), new Vector2Int(4,5), directionsRed[0], 1),
        new Area(new Vector2Int(6,3), new Vector2Int(4,5), directionsRed[1], 1),
        new Area(new Vector2Int(10,0), new Vector2Int(4,5), directionsRed[0], 1),
        new Area(new Vector2Int(14, 3), new Vector2Int(4,5), directionsRed[1], 1),
        new Area(new Vector2Int(18,0), new Vector2Int(4,5), directionsRed[0], 1),
        new Area(new Vector2Int(22, 3), new Vector2Int(4,5), directionsRed[1], 1),
        new Area(new Vector2Int(26, 0), new Vector2Int(4,5), directionsRed[0], 1),
        new Area(new Vector2Int(30 , 3), new Vector2Int(4,5), directionsRed[1], 1),
        new Area(new Vector2Int(34 , 0), new Vector2Int(4,5), directionsRed[1], 1),
        new Area(new Vector2Int(38 , 0), new Vector2Int(4,5), directionsRed[1], 1),
    };


    public const int numOfGreenArea = 4;
    public static readonly Direction[][] directionsGreen = new Direction[1][]
    {
        new Direction[]
        {
            Direction.wait
        }
    };

    public Area[] greenAreas = new Area[numOfGreenArea]
    {
        new Area(new Vector2Int(0 , 0), new Vector2Int(2,10), directionsGreen[0], 1),
        new Area(new Vector2Int(15 , 0), new Vector2Int(2,10), directionsGreen[0], 1, false),
        new Area(new Vector2Int(25 , 0), new Vector2Int(2,10), directionsGreen[0], 1, false),
        new Area(new Vector2Int(38 , 0), new Vector2Int(2,10), directionsGreen[0], 1)
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
