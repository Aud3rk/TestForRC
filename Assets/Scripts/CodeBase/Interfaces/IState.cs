namespace CodeBase.Infrustructure
{
    public interface IState : IExetableState
    {
        void Enter();
    }
    public interface IPayloadedState<TPayLoad> : IExetableState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IExetableState
    {
        void Exit();
    }
    
}