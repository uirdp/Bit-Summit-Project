using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DirectionSpace.Directions;

public class MatrixManual 
{
    public Direction[] shiftDirections;
    public int index;

    public MatrixManual(Direction[] di) 
    {
        this.shiftDirections = di;
        index = 0;
    }

    public Direction GetDirection()
    {
        return shiftDirections[index];
    }

    public void GotoNextStep()
    {
        index++;
    }

    public void BackToTheFirstStep()
    {
        index = 0;
    }
    
}
