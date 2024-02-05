using static DirectionSpace.Directions;
using System.Collections.Generic;

//All static matrices should inherit this Interface

//MatrixInstant(Instance of a static matrix) should look for a dictionary
//through this Interface
interface IReadOnlyMatrixModel
{
    int[,] Matrix { get; }
    
    List<int[,]> MovingMatrices { get; }
    
    Direction[] Manual { get; }
}
