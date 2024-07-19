using System;
using UniRx;

namespace Player.Input
{
    public class InputService: IInput, IDisposable
    {
        private readonly Subject<Unit> _abilityPressed = new();
        private PlayerInput _playerInput;
        
        public void EnableInput()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            _playerInput.Keyboard.Ability.performed += _ =>
                _abilityPressed.OnNext(Unit.Default);
        }

        public float GetMoveAxis() =>
            _playerInput.Keyboard.Move.ReadValue<float>();

        public IObservable<Unit> AbilityPressed =>
            _abilityPressed;

        public void Dispose()
        {
            _playerInput.Disable();
            _abilityPressed.Dispose();
        }
    }
}