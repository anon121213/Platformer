using Data.StaticData;
using UnityEngine.AddressableAssets;

namespace FSM.States
{
    public class BootstrapState: IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticDataProvider _staticDateProvider;

        public BootstrapState(GameStateMachine gameStateMachine, IStaticDataProvider staticDateProvider)
        {
            _gameStateMachine = gameStateMachine;
            _staticDateProvider = staticDateProvider;
        }

        public void Enter() =>
            _gameStateMachine.Enter<LoadLevelState, AssetReference>(_staticDateProvider.AssetsReferences.MainScene);

        public void Exit() { }
    }
}