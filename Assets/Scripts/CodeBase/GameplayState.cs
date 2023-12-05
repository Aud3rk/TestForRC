namespace CodeBase.Infrustructure
{
    public class GameplayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly InputService.InputService _inputService;

        public GameplayState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _inputService  = new InputService.InputService(); 
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            
        }
    }
}