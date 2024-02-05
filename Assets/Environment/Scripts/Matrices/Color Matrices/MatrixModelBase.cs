using static DirectionSpace.Directions;
interface IReaderMatrixModel
{
    static readonly int[,] matrix;
    static readonly int[,] movingMatrix;
    static readonly Direction[] manual;
}
