using static DirectionSpace.Directions;
using System.Collections.Generic;

//All static matrices should inherit this Interface

//MatrixInstant(Instance of a static matrix) should look for a dictionary
//through this Interface
public interface IMatrixModel
{
    public ref int[,] Matrix { get; }
    
    public List<int[,]> MovingMatrices { get; }

    ref Point[] PosOfMovingMatrices { get; }
    ref Point[] SizeOfMovingMatrices { get; }

    public Direction[] Directions { get; }

    
}
