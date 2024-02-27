using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class BorderModel : IMatrixModel
{
    public static readonly string name = "border";

    int[,] matrix =
                    {
                        {2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                        { 2, 2, 2, 2, },
                    };

    public const int numOfRedArea = 0;

    public static readonly Direction[][] directionsRed = null;

    public Area[] redAreas =  null;


    public const int numOfGreenArea = 0;
    public static readonly Direction[][] directionsGreen = null;

    public Area[] greenAreas = null;

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
