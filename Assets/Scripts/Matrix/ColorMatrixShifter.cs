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
    public IMatrixModel colorMatrix;       //use either one of them, maybe union?
    private NoAreaMatrixBase noAreaMatrix;

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
    public void ShiftRight(ref Area area)
    {
        area.Pos = new Vector2Int(area.Pos.x + 1, area.Pos.y);
    }
    public void ShiftLeft(ref Area area)
    {
        area.Pos = new Vector2Int(area.Pos.x - 1, area.Pos.y);
    }

    public void ShiftUp(ref Area area)
    {
        area.Pos = new Vector2Int(area.Pos.x, area.Pos.y - 1);
    }

    public void ShiftDown(ref Area area)
    {
        area.Pos = new Vector2Int(area.Pos.x, area.Pos.y + 1);
    }

    public void ShiftDownRight(ref Area area)
    {
        area.Pos = new Vector2Int(area.Pos.x + 1, area.Pos.y + 1);
    }

    public void ResetPosX(ref Area area)
    {
        area.ResetPosX();
    }
    public void StretchUp(int which)
    {

    }

    public void FormWave(ref Area area, int rewriteInd)
    {
        colorMatrix.RewriteAreas[rewriteInd].Pos.Set(area.Pos.x, area.Pos.y);
        colorMatrix.RewriteAreas[rewriteInd].Size.Set(area.Pos.x, area.Pos.y);

        area.Pos = new Vector2Int(area.Pos.x + 1, area.Pos.y + 1);
        area.Size = new Vector2Int(area.Size.x + 1, area.Pos.y + 1);
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

    public void ReverseMatrix()
    {
        for(int ix = 0; ix < colorMatrix.Matrix.GetLength(0); ix++)
        {
            for(int iy = 0; iy < colorMatrix.Matrix.GetLength(1); iy++)
            {
                if (colorMatrix.Matrix[ix, iy] == 1)
                {
                    colorMatrix.Matrix[ix, iy] = 0;
                }
                else if (colorMatrix.Matrix[ix, iy] == 0)
                {
                    colorMatrix.Matrix[ix, iy] = 1;
                }

                else continue;
                
            }
        }
        useReset = false;
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

        if (typeof(NoAreaMatrixBase) == colorMatrix.GetType()) { 

        }

            _numOfRed = colorMatrix.NumOfRed;
        _numOfGreen = colorMatrix.NumOfGreen;

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
        useReset = true; //reset by default
        //move red
        if (colorMatrix.RedAreas != null)
        {
            for (int i = 0; i < colorMatrix.RedAreas.Length; i++)
            {
                var rArea = colorMatrix.RedAreas[i];

                if (rArea.IsActive) ReadManual(ref rArea, i);
                else rArea.CountDownActivation();
            }
        }

        //move green
        if (colorMatrix.GreenAreas != null)
        {
            for (int i = 0; i < colorMatrix.GreenAreas.Length; i++)
            {
                var gArea = colorMatrix.GreenAreas[i];

                if (gArea.IsActive) ReadManual(ref gArea, i);
                else gArea.CountDownActivation();
            }
        }

        if(useReset) ResetMatrix();
        RenderColorsOnMatrix();

        yield return new WaitForSeconds(interval);

        SendSignal();

        StartCoroutine(ShiftMatrix());
    }

    private void ReadManual(ref Area area, int ind)
    {     
        Direction dir = area.Manual[area.ManualIndex++];

        if (area.ManualIndex >= area.Manual.Length)
        {
            area.ResetManual(); //index = 0, pos & size = init pos & size
        }

        switch (dir)
        {
            case Direction.right:
                ShiftRight(ref area);
                break;
            case Direction.left:
                ShiftLeft(ref area);
                break;
            case Direction.up:
                ShiftUp(ref area);
                break;
            case Direction.down:
                ShiftDown(ref area);
                break;
            case Direction.downRight:
                ShiftDownRight(ref area);
                break;
            case Direction.wave:
                FormWave(ref area, ind);
                break;
            case Direction.erase:
                EraseMatrix();
                break;
            case Direction.resetPosX:
                ResetPosX(ref area);
                break;
            case Direction.reverse:
                ReverseMatrix();
                break;

        }
    }


    //plz change name!
    private void RenderColorsOnMatrix()
    {
        //from the least priority to the highest
        //render red area
        if (colorMatrix.RedAreas != null)
        {
            foreach (var rArea in colorMatrix.RedAreas)
            {
                for (int ix = rArea.Pos.x; ix < rArea.Pos.x + rArea.Size.x; ix++)
                {
                    for (int iy = rArea.Pos.y; iy < rArea.Pos.y + rArea.Size.y; iy++)
                    {
                        if (ix >= colorMatrix.Matrix.GetLength(0))
                        {
                            colorMatrix.Matrix[ix - colorMatrix.Matrix.GetLength(0), iy] = 1;
                        }

                        else colorMatrix.Matrix[ix, iy] = 1;
                    }
                }
            }
        }

        //render rewrite
        if (colorMatrix.RewriteAreas != null)
        {
            foreach (var wArea in colorMatrix?.RewriteAreas)
            {
                for (int ix = wArea.Pos.x; ix < wArea.Pos.x + wArea.Size.x; ix++)
                {
                    for (int iy = wArea.Pos.y; iy < wArea.Pos.y + wArea.Size.y; iy++)
                    {
                        colorMatrix.Matrix[ix, iy] = 0;
                    }
                }
            }
        }

        //render green area
        if (colorMatrix.GreenAreas != null)
        {
            foreach (var gArea in colorMatrix.GreenAreas)
            {
                for (int ix = gArea.Pos.x; ix < gArea.Pos.x + gArea.Size.x; ix++)
                {
                    for (int iy = gArea.Pos.y; iy < gArea.Pos.y + gArea.Size.y; iy++)
                    {
                        colorMatrix.Matrix[ix, iy] = 2;
                    }
                }
            }
        }
    }

}
