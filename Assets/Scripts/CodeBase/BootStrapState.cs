namespace CodeBase.Infrustructure
{
    public class BootStrapState : IState
    {
        private const string _initialScene = "InitialScene";
        private readonly GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public BootStrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            EnterLoadLevel();
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>("SampleScene");

        private void RegisterServices()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}