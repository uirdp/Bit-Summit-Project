using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Use group matricies when group members are adjacent to each other
public class CubeColorMatrix : MonoBehaviour 
{
    //as A super class of all cubes

    public int[,] matrix;

    public int posOfMovingMatrixX; //it's zero origin
    public int posOfMovingMatrixY;

    public int sizeOfMovingMatrixX;
    public int sizeOfMovingMatrixY;

    public virtual void ShiftMatrix() { }
    
    public void SendSignal()
    {

    }
}
