using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObject/PlayerSettings")]
    public class DefaultPlayerSettings : ScriptableObject
    {
        [SerializeField, Range(0, 10)] private int _healthPoint;
        [SerializeField, Range(0, 30)] private int _speed;

        public int HP =>
            _healthPoint; 
        
        public int Speed =>
            _speed;
    }   
}