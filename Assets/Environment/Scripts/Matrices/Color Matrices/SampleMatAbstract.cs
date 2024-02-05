using static DirectionSpace.Directions;

public class SampleColorMatrixModel : IReaderMatrixModel 
{
    public static readonly int[,] matrix = new int[,]{
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };

    public const int numOfMovingMatrices = 1;
    public static readonly int[,] movingMatrix = new int[,]
    {
        {1, 1, 1 },
        {1, 1, 1 },
        {1, 1, 1 },
    };

    public static readonly Direction[] manual = new Direction[]
    {
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
        Direction.right,
    };

    public int[,] Matrix => matrix;
    public int[,] MovingMatrix => movingMatrix;
    public Direction[] Manual => manual;

}


//should be more generic
public class SampleMatAbstract : ColorMatrixBase
{
    private string _name = "sample";

    public SampleMatAbstract()
    {
        Init();
    }

    public override void Init()
    {
        name = _name;
        matrix = SampleColorMatrixModel.matrix;
        manual = new MatrixManual(SampleColorMatrixModel.manual);

        posOfMovingMatrices = new Point[SampleColorMatrixModel.numOfMovingMatrices]
        {
             new Point(0, 0)
        };

        sizeOfMovingMatrices = new Point[SampleColorMatrixModel.numOfMovingMatrices]
        {
            new Point(3, 3)
        };
    }
}
