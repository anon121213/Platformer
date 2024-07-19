using Factories;

namespace FSM.States
{
    public class CreateGameObjectsState: IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _gameStateMachine;

        public CreateGameObjectsState(IGameFactory gameFactory,
            GameStateMachine gameStateMachine)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            CreateGameObjects();
        }

        private async void CreateGameObjects()
        {
            await _gameFactory.CreatePlayer();
        }
        
        public void Exit()
        {
            
        }
    }
}