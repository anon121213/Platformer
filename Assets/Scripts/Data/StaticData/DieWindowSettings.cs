using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "DieWindowSettings", menuName = "ScriptableObject/DieWindowSettings")]
    public class DieWindowSettings: ScriptableObject
    {
        [SerializeField, Range(0, 3000)] private float _endWindowPositionValue;
        [SerializeField, Range(0, 30)] private float _duration;
        [SerializeField] private bool _snapping;

        public float EndWindowPositionValue =>
            _endWindowPositionValue;

        public float Duration =>
            _duration;

        public bool Snapping =>
            _snapping;
    }
}