using System;

namespace CodeBase.Infrustructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, onLoaded);
           
        }

        private void onLoaded()
        {
            _gameStateMachine.Enter<GameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}