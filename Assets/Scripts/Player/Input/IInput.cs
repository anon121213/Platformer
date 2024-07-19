using System;
using UniRx;

namespace Player.Input
{
    public interface IInput
    {
        void EnableInput();
        float GetMoveAxis();
        IObservable<Unit> AbilityPressed { get; }
    }
}