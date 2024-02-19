using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static DirectionSpace.Directions;
using UnityEditor.ShaderGraph;
using System.Linq;

/*DamageArea{ vec2 size; vec2 pos };
GreenArea{ vec2 size; vec2 pos };
DamageArea[] damageAreas;
GreenArea[] greenAreas;

and you use int[,] matrix just to cache final result after everything moved/added/removed this frame 
added bonus that they can be moved independently*/
public class ColorMatrixShifter : MonoBehaviour
{
    //public SampleColorMatrix colorMatrix;
    public CubeSignalManager signalManager;
    public IMatrixModel colorMatrix;

    public string matrixName = "sample";
    private MatrixDictionary _dict;

    public float interval = 0.5f;

    private Vector2[] _initPosRed;
    private Vector2[] _initSizeRed;
    private int _numOfRed;

    private Vector2[] _initPosGreen;
    private Vector2[] _initSizeGreen;
    private int _numOfGreen;

    public bool useReset = true;
    private int[,] initMatrix = null;
    //which -> which Matrix to move, should be renamed

    //----------------------------shift method----------------------------------------------------------
    public void ShiftRight(Area area)
    {
        area.Pos.Set(area.Pos.x + 1, area.Pos.y);
    }
    public void ShiftLeft(Area area)
    {
        area.Pos.Set(area.Pos.x - 1, area.Pos.y);
    }

    public void ShiftUp(Area area)
    {
        area.Pos.Set(area.Pos.x, area.Pos.y - 1);
    }

    public void ShiftDown(Area area)
    {
        area.Pos.Set(area.Pos.x, area.Pos.y + 1);
    }

    public void StretchUp(int which)
    {

    }

    public void FormWave(Area area, int rewriteInd)
    {
        colorMatrix.RewriteAreas[rewriteInd].Pos.Set(area.Pos.x, area.Pos.y);
        colorMatrix.RewriteAreas[rewriteInd].Size.Set(area.Pos.x, area.Pos.y);

        area.Pos.Set(area.Pos.x + 1, area.Pos.y + 1);
        area.Size.Set(area.Pos.x + 1, area.Pos.y + 1);
    }

    public void EraseMatrix()
    {
        int xsz = colorMatrix.Matrix.GetLength(0);
        int ysz = colorMatrix.Matrix.GetLength(1);

        for(int i = 0; i < xsz; i++)
        {
            for(int j = 0; j < ysz; j++)
            {
                colorMatrix.Matrix[i, j] = 0;
            }
        }

    }

    //----------------------------end of shift method----------------------------------------------------------

    

    public void SendSignal()
    {
        signalManager.ChangeCubeMaterials(ref colorMatrix.Matrix);
    }

    public void Init()
    {
        //Get a matrix to shift from the dictionary
        _dict = new MatrixDictionary();
        colorMatrix = _dict.ReturnMatrix(matrixName);

        _numOfRed = colorMatrix.NumOfRed;
        _numOfGreen = colorMatrix.NumOfGreen;

        Debug.Log(colorMatrix.RedAreas[0].Pos);

        _initPosRed = new Vector2[_numOfRed];
        _initSizeRed = new Vector2[_numOfRed];

        _initPosGreen = new Vector2[_numOfGreen];
        _initSizeGreen = new Vector2[_numOfGreen];

        for(int i = 0; i < _numOfRed; i++)
        {
            _initPosRed[i] = colorMatrix.RedAreas[i].Pos;
            _initSizeRed[i] = colorMatrix.RedAreas[i].Size;
        }

        for(int i = 0;i < _numOfGreen; i++)
        {
            _initPosGreen[i] = colorMatrix.GreenAreas[i].Pos;
            _initSizeGreen[i] = colorMatrix.GreenAreas[i].Size;
        }

        if (useReset) initMatrix = colorMatrix.InitMatrix;

    }
    public void Start()
    {
        StartCoroutine(ShiftMatrix());
    }

    public void Awake()
    {
        Init();
    }

    private void ResetMatrix()
    {
        for(int ix = 0; ix < colorMatrix.Matrix.GetLength(0); ix++)
        {
            for(int iy = 0; iy < colorMatrix.Matrix.GetLength(1); iy++)
            {
                colorMatrix.Matrix[ix, iy] = 0;
            }
        }
    }
    public IEnumerator ShiftMatrix()
    {
        for (int i = 0; i < colorMatrix.RedAreas.Length; i++)
        {
            var rArea = colorMatrix.RedAreas[i];
            Direction dir = rArea.Manual[rArea.ManualIndex++];

            if (rArea.ManualIndex >= rArea.Manual.Length)
            {
                rArea.ManualIndex = 0;
            }

            switch (dir)
            {
                case Direction.right:
                    ShiftRight(rArea);
                    break;
                case Direction.left:
                    ShiftLeft(rArea);
                    break;
                case Direction.up:
                    ShiftUp(rArea);
                    break;
                case Direction.down:
                    ShiftDown(rArea);
                    break;
                case Direction.wave:
                    FormWave(rArea, i);
                    break;
                case Direction.erase:
                    EraseMatrix();
                    break;
            }

            
        }

        ResetMatrix();
        RenderColorsOnMatrix();

        yield return new WaitForSeconds(interval);

        SendSignal();

        StartCoroutine(ShiftMatrix());
    }

    //plz change name!
    private void RenderColorsOnMatrix()
    {
        //from the least priority to the highest
        //render red area
        foreach(var rArea in colorMatrix.RedAreas)
        {
            for(int ix = rArea.Pos.x; ix <= rArea.Pos.x + rArea.Size.x; ix++)
            {
                for(int  iy = rArea.Pos.y; iy <= rArea.Pos.y + rArea.Size.y; iy++)
                {
                    colorMatrix.Matrix[ix, iy] = 1;
                }
            }
        }

        //render rewrite
        if (colorMatrix?.RewriteAreas != null)
        {
            foreach (var wArea in colorMatrix?.RewriteAreas)
            {
                for (int ix = wArea.Pos.x; ix <= wArea.Pos.x + wArea.Size.x; ix++)
                {
                    for (int iy = wArea.Pos.y; iy <= wArea.Pos.y + wArea.Size.y; iy++)
                    {
                        colorMatrix.Matrix[ix, iy] = 1;
                    }
                }
            }
        }

        //render green area
        foreach(var gArea in colorMatrix.GreenAreas)
        {
            for (int ix = gArea.Pos.x; ix <= gArea.Pos.x + gArea.Size.x; ix++)
            {
                for (int iy = gArea.Pos.y; iy <= gArea.Pos.y + gArea.Size.y; iy++)
                {
                    colorMatrix.Matrix[ix, iy] = 2;
                }
            }
        }
    }

}
