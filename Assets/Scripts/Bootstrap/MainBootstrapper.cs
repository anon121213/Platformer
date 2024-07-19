using Cinemachine;
using FSM;
using FSM.States;
using UnityEngine;
using VContainer;

namespace Bootstrap
{
    public class MainBootstrapper: MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        
        private GameStateMachine _gameStateMachine;
        private CreateGameObjectsState _createGameObjectsState;
        
        [Inject]
        private void Inject(GameStateMachine gameStateMachine,
            CreateGameObjectsState createGameObjectsState)
        {
            _gameStateMachine = gameStateMachine;
            _createGameObjectsState = createGameObjectsState;
        }

        public void Start()
        {
            AddStates(_gameStateMachine);
            _gameStateMachine.Enter<CreateGameObjectsState, CinemachineVirtualCamera>(_virtualCamera);
        }

        private void AddStates(GameStateMachine gameStateMachine)
        {
            gameStateMachine.AddState(typeof(CreateGameObjectsState), _createGameObjectsState);
        }
    }
}