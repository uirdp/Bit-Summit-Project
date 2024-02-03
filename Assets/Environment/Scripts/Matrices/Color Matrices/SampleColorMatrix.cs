using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleColorMatrix : MonoBehaviour
{
    public int[,] matrix = new int[,]{
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

    public int posOfMovingMatrixX = 0; //it's zero origin
    public int posOfMovingMatrixY = 0;

    public int sizeOfMovingMatrixX = 3;
    public int sizeOfMovingMatrixY = 3;
}