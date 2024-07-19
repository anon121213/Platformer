using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObject/PlayerSettings")]
    public class DefaultPlayerSettings : ScriptableObject
    {
        [SerializeField, Range(0, 10)] private int _healthPoint;
        [SerializeField, Range(0, 30)] private int _speed;
        [SerializeField, Range(0, 20)] private float _bulletCreateDelay;
        [SerializeField, Range(0, 20)] private float _bulletLifeTime;

        public int HP =>
            _healthPoint; 
        
        public int Speed =>
            _speed;

        public float BulletCreateDelay =>
            _bulletCreateDelay;

        public float BulletLifeTime =>
            _bulletLifeTime;
    }   
}