using static DirectionSpace.Directions;

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
