using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "BirdSettings", menuName = "ScriptableObject/BirdSettings")]
    public class BirdSettings: ScriptableObject
    {
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 20)] private float _lifeTime;
        [SerializeField, Range(0, 20)] private float _delay;

        public float Speed =>
            _speed;

        public float LifeTime =>
            _lifeTime;

        public float Delay =>
            _delay;
    }
}