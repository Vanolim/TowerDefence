public interface IState : IExitableState
{
    public void Enter();
}

public interface IExitableState
{
    public void Exit();
}