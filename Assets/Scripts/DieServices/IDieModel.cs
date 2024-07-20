namespace DieServices
{
    public interface IDieModel
    {
        float EndWindowPositionValue { get; }
        float Duration { get; }
        bool Snapping { get; }
    }
}