using System;
using Data.Services;
using Data.StaticData;
using Player.Abilities;
using Player.Input;
using Player.Move;
using UniRx;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public bool isDamageble = true;
        public SpriteRenderer sprite;
        
        [SerializeField] private Rigidbody2D _rb;
        
        private IInput _input;
        private IMoveService _moveService;
        private IStaticDataProvider _staticDataProvider;
        private IDisposable _abilitySubscribe;
        private IDisposeService _disposeService;
        private IAbility _ability;
        
        private float _speed;
        
        [Inject]
        private void Inject(IInput input, 
            IMoveService moveService,
            IStaticDataProvider staticDataProvider,
            IDisposeService disposeService,
            IAbility ability)
        {
            _input = input;
            _moveService = moveService;
            _staticDataProvider = staticDataProvider;
            _disposeService = disposeService;
            _ability = ability;
        }

        private void Awake()
        {
            _input.EnableInput();
            _abilitySubscribe = _input.AbilityPressed.Subscribe(_ => UseIvisible());
            _disposeService.AddDisposableObject(_abilitySubscribe);
            
            _speed = _staticDataProvider.PlayerSettings.Speed;
            isDamageble = _staticDataProvider.PlayerSettings.IsDamageble;
        }

        private void FixedUpdate() =>
            _moveService.Move1D(_rb,_input.GetMoveAxis() * _speed);

        private void UseIvisible() =>
            _ability?.UseAbility(this);
    }
}
