using Cinemachine;
using Factories;
using UnityEngine;

namespace FSM.States
{
    public class CreateGameObjectsState: IPayloadedState<CinemachineVirtualCamera>
    {
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _gameStateMachine;
        private CinemachineVirtualCamera _virtualCamera;
        
        public CreateGameObjectsState(IGameFactory gameFactory,
            GameStateMachine gameStateMachine)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(CinemachineVirtualCamera payload)
        {
            _virtualCamera = payload;
            CreateGameObjects();
        }

        private async void CreateGameObjects()
        {
            GameObject player = await _gameFactory.CreatePlayer();
            
            await _gameFactory.CreateHud();
            await _gameFactory.CreateHp();
            await _gameFactory.CreateBulletsCreator();
            await _gameFactory.CreateBirdCreator();
            
            _virtualCamera.Follow = player.transform;
        }

        public void Exit()
        {
            
        }
    }
}