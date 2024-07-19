using System;
using Data.Services;
using Data.StaticData;
using Player.Input;
using Player.Move;
using UniRx;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        private IInput _input;
        private IMoveService _moveService;
        private IStaticDataProvider _staticDataProvider;
        private IDisposable _abilitySubscribe;
        private IDisposeService _disposeService;
        
        private float _speed;
        
        [Inject]
        private void Inject(IInput input, 
            IMoveService moveService,
            IStaticDataProvider staticDataProvider,
            IDisposeService disposeService)
        {
            _input = input;
            _moveService = moveService;
            _staticDataProvider = staticDataProvider;
            _disposeService = disposeService;
        }

        private void Awake()
        {
            _input.EnableInput();
            _abilitySubscribe = _input.AbilityPressed.Subscribe(_ => UseAbility());
            _disposeService.AddDisposableObject(_abilitySubscribe);
            _speed = _staticDataProvider.DefaultPlayerSettings.Speed;
        }

        private void FixedUpdate() =>
            _moveService.Move1D(_rb,_input.GetMoveAxis() * _speed);

        private void UseAbility()
        {
            
        }
    }
}
