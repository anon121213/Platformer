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
        [SerializeField, Range(0, 1)] private float _fadeIntensity;
        [SerializeField, Range(0, 5)] private float _fadeDuration;
        
        [SerializeField, Range(0, 5)] private float _dieAnimDuration;
        [SerializeField] private Vector3 _dieAnimScale;
        

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

        public float FadeIntensity =>
            _fadeIntensity;

        public float FadeDuration =>
            _fadeDuration;

        public float DieAnimDuration =>
            _dieAnimDuration;

        public Vector3 DieAnimScale =>
            _dieAnimScale;
    }   
}