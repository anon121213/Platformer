using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObject/BulletSettings")]
    public class BulletSettings: ScriptableObject
    {
        [SerializeField, Range(0, 20)] private float _bulletCreateDelay;
        [SerializeField, Range(0, 20)] private float _bulletLifeTime;
        [SerializeField, Range(0, 100)] private float _speed;
        
        public float BulletCreateDelay =>
            _bulletCreateDelay;

        public float BulletLifeTime =>
            _bulletLifeTime;

        public float Speed =>
            _speed;
    }
}