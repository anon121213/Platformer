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
        private CinemachineVirtualCamera _virtualCamera;
        
        public CreateGameObjectsState(IGameFactory gameFactory) =>
            _gameFactory = gameFactory;

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
            await _gameFactory.CreateHp();
            
            List<UniTask> tasks = new()
            {
                _gameFactory.CreateDieWindow(),
                _gameFactory.CreateBulletsCreator(),
                _gameFactory.CreateBirdCreator()
            };
            
            await UniTask.WhenAll(tasks);
        }
        
        public void Exit() { }
    }
}