using UnityEngine;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObject/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField, Range(0, 10)] private int _healthPoint;
        [SerializeField, Range(0, 30)] private int _speed;
        
        [SerializeField] private bool _isDamageble;
        [SerializeField, Range(0, 500)] private int _inviseCoolDown;
        [SerializeField, Range(0, 500)] private int _inviseLifeTime;

        public int Hp =>
            _healthPoint;

        public int Speed =>
            _speed;

        public bool IsDamageble =>
            _isDamageble;

        public int InviseCoolDown =>
            _inviseCoolDown;

        public int InviseLifeTime =>
            _inviseLifeTime;
    }   
}