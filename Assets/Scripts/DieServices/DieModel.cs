using Data.StaticData;

namespace DieServices
{
    public class DieModel : IDieModel
    {
        private float _endWindowPositionValue;
        private float _duration;
        private bool _snapping;
        
        public DieModel(IStaticDataProvider dataProvider)
        {
            _endWindowPositionValue = dataProvider.DieWindowSettings.EndWindowPositionValue;
            _duration = dataProvider.DieWindowSettings.Duration;
            _snapping = dataProvider.DieWindowSettings.Snapping;
        }

        public float EndWindowPositionValue =>
            _endWindowPositionValue;

        public float Duration =>
            _duration;

        public bool Snapping =>
            _snapping;
    }
}