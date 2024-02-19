using static DirectionSpace.Directions;
using System.Collections.Generic;
using System.Numerics;

//All static matrices should inherit this Interface

//MatrixInstant(Instance of a static matrix) should look for a dictionary
//through this Interface

public struct Area
{
    public Area(Vector2 pos, Vector2 size, Direction[] man)
    {
        Position = pos;
        Size = size;
        Manual = man;
    }

    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }
    public Direction[] Manual { get; }

}
public interface IMatrixModel
{
    public int[,] InitMatrix { get; }
    public ref int[,] Matrix { get; }
    public Area[] RedAreas { get; }
    public Area[] GreenAreas { get; }
    
}
