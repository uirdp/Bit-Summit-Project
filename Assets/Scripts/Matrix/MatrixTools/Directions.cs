﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionSpace { 
 public static class Directions
{
    public enum Direction
    {
        //basic movements
        wait,
        up,
        down,
        left,
        right,
        upRight, //➚
        downRight, //➷
        upLeft,
        downLeft,

        //stretch
        stretchUp,
        stretchDown,
        stretchLeft,
        stretchRight,

        //when calculating a movement is difficult 
        change //changes to another matrix
    }
}
}
