using System;
using System.Collections.Generic;

namespace CodeBase.Infrustructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExetableState> _states;
        private IExetableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExetableState>()
            {
                [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
                [typeof(GameplayState)] = new GameplayState(this, sceneLoader),
            };

        }
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExetableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }


        public void Enter<TState, TPayload>(TPayload payLoad) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }
        
        private TState GetState<TState>() where TState : class, IExetableState => 
            _states[typeof(TState)] as TState;
    }
}