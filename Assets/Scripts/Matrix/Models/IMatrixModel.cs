using static DirectionSpace.Directions;
using System.Collections.Generic;
using UnityEngine;

//All static matrices should inherit this Interface

//MatrixInstant(Instance of a static matrix) should look for a dictionary
//through this Interface

public class Area
{
    //public Vec2 currentPos maybe should have this 
    private Vector2Int _initPos;
    private Vector2Int _initSize;

    private bool _isActive = true;

    private int _turnsTillActivation;
    private int _turnsTillReset; 
    private int _turns = 0; //how many times the Direction[] was completed

    public bool IsWaiting = false; 

    public Area(Vector2Int pos, Vector2Int size, Direction[] man, int turnsTillReset)
    {
        _initPos= pos;
        Pos = _initPos;

        _initSize = size;
        Size = _initSize;

        _turnsTillReset = turnsTillReset;
        _turnsTillActivation = 0;

        Manual = man;
        ManualIndex = 0;
    }

    public Area(Vector2Int pos, Vector2Int size, Direction[] man, int turnsTillReset, bool isActive)
    {
        _initPos = pos;
        Pos = _initPos;

        _initSize = size;
        Size = _initSize;

        _turnsTillReset = turnsTillReset;
        _turnsTillActivation = 10000;

        Manual = man;
        ManualIndex = 0;

        _isActive = isActive;
    }

    public Area(Vector2Int pos, Vector2Int size, Direction[] man, int turnsTillReset, int turnsTillActivation)
    {
        _initPos = pos;
        Pos = _initPos;

        _initSize = size;
        Size = _initSize;

        _turnsTillReset = turnsTillReset;

        _turnsTillActivation = turnsTillActivation;
        _isActive = false;

        Manual = man;
        ManualIndex = 0;
    }

    public Vector2Int Pos { get; set; }
    public Vector2Int Size { get; set; }
    public Direction[] Manual { get; }

    public bool IsActive => _isActive;

    public int ManualIndex { get; set; }

    public void ResetManual()
    {
        ManualIndex = 0;
        _turns++;
        if (_turns >= _turnsTillReset) ResetArea();
    }

    public void ResetArea()
    {
        Pos = _initSize;
        Pos = _initPos;
        _turns = 0;
    }

    public void ResetPosX()
    {
        Pos = new Vector2Int(_initPos.x, Pos.y);
    }

    public void CountDownActivation()
    {
        _turnsTillActivation--;
        if (_turnsTillActivation <= 0) Activate();
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}
public interface IMatrixModel
{
    //probably redundunt?
    public int[,] InitMatrix { get; }
    public ref int[,] Matrix { get; }
    public ref Area[] RedAreas { get; }
    public ref Area[] GreenAreas { get; }

    //when it's hard to render simply by two for loops as x * y...
    //when the area cannot simply be represented as products of rows and columns
    public ref Area[] RewriteAreas { get; }

    public int NumOfRed { get; }
    public int NumOfGreen { get; }
    
}

public abstract class NoAreaMatrixBase : IMatrixModel
{
    //should be replaced with a Manual class?
    private bool _isActive = true;

    private int _turnsTillActivation = 0;
    //how many times the Direction[] was completed

    public int[,] matrix;
    public Direction[] manual;

    public Area[] redArea = null;
    public Area[] greenArea = null;
    public Area[] rewriteArea = null;
    public int[,] InitMatrix { get; }
    public ref int[,] Matrix => ref matrix;
    public ref Area[] RedAreas => ref redArea;
    public ref Area[] GreenAreas => ref greenArea;

    //when it's hard to render simply by two for loops as x * y...
    //when the area cannot simply be represented as products of rows and columns
    public ref Area[] RewriteAreas => ref rewriteArea;

    public int NumOfRed { get; }
    public int NumOfGreen { get; }

    public Direction[] Manual { get; }

    public bool IsActive => _isActive;
    public int ManualIndex { get; set; }

    public NoAreaMatrixBase(int[,] mat, Direction[] man)
    {
        matrix = mat;
        Manual = man;
    }

    public void ResetManual()
    {
        ManualIndex = 0;
    }

    public void CountDownActivation()
    {
        _turnsTillActivation--;
        if (_turnsTillActivation <= 0) Activate();
    }

    public void Activate()
    {
        _isActive = true;
    }
}
