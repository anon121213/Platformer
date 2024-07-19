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

        private float _speed;
        
        [Inject]
        private void Inject(IInput input, 
            IMoveService moveService,
            IStaticDataProvider staticDataProvider)
        {
            _input = input;
            _moveService = moveService;
            _staticDataProvider = staticDataProvider;
        }

        private void Awake()
        {
            _input.EnableInput();
            _input.AbilityPressed.Subscribe(_ => UseAbility());
            _speed = _staticDataProvider.DefaultPlayerSettings.Speed;
        }

        private void FixedUpdate() =>
            _moveService.Move1D(_rb,_input.GetMoveAxis() * _speed);

        private void UseAbility()
        {
            
        }
    }
}
