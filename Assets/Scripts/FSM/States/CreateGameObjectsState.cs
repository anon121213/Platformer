using System.Collections.Generic;
using Cinemachine;
using Cysharp.Threading.Tasks;
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
            _virtualCamera.Follow = player.transform;
            
            await _gameFactory.CreateHud();
            
            List<UniTask> tasks = new()
            {
                _gameFactory.CreateHp(),
                _gameFactory.CreateBulletsCreator(),
                _gameFactory.CreateBirdCreator()
            };

            await UniTask.WhenAll(tasks);
        }

        public void Exit()
        {
            
        }
    }
}