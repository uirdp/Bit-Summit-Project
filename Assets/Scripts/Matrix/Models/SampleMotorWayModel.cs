using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class SampleMotorWayModel : IMatrixModel
{

    public static readonly string name = "motorway";

    public int[,] matrix = new int[,]
    {
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },
        {0, 0, 0, 0, 0, 0, 0, 0, },

    };

    public const int numOfRedArea = 1;

    public static readonly Direction[][] directionsRed = new Direction[1][]
   {
        new Direction[]
        {
            Direction.allRed
        },
    };


    public Area[] redArea = new Area[numOfRedArea]
    {
        new Area(new Vector2Int(0, 0), new Vector2Int(0,0), directionsRed[0],0)
    };

    public const int numOfGreenArea = 6;

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

    public Area[] GreenAreas = new Area[numOfGreenArea]
    {
        new Area()
    } 

}
