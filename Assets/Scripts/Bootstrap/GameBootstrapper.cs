using FSM;
using FSM.States;
using VContainer.Unity;

namespace Bootstrap
{
    public class GameBootstrapper : IStartable
    {
        private readonly BootstrapState _bootstrapState;
        private readonly LoadDefaultSettingsState _loadDefaultSettingsState;
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadLevelState _loadLevelState;

        public GameBootstrapper(BootstrapState bootstrapState,
            LoadDefaultSettingsState loadDefaultSettingsState,
            LoadLevelState loadLevelState,
            GameStateMachine gameStateMachine)
        {
            
            _bootstrapState = bootstrapState;
            _loadDefaultSettingsState = loadDefaultSettingsState;
            _gameStateMachine = gameStateMachine;
            _loadLevelState = loadLevelState;
        }

        public void Start()
        {
            AddStates(_gameStateMachine);
            _gameStateMachine.Enter<BootstrapState>();
        }

        private void AddStates(GameStateMachine gameStateMachine)
        {
            gameStateMachine.AddState(typeof(BootstrapState), _bootstrapState);
            gameStateMachine.AddState(typeof(LoadLevelState), _loadLevelState);
            gameStateMachine.AddState(typeof(LoadDefaultSettingsState), _loadDefaultSettingsState);
        }
    }
}