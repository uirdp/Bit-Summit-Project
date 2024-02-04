using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixManual 
{
    public int[] shiftDirections;
    public int index = 0;

    public void GotoNextStep()
    {
        index++;
    }

    public void BackToTheFirstStep()
    {
        index = 0;
    }

}
