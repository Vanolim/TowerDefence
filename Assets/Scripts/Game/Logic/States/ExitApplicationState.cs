using UnityEngine;

public class ExitApplicationState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private IExitApplicationHandler _exitApplicationHandler;
    
    public ExitApplicationState(GameStateMachine gameStateMachine, IExitApplicationHandler exitApplicationHandler)
    {
        _gameStateMachine = gameStateMachine;
        _exitApplicationHandler = exitApplicationHandler;

        exitApplicationHandler.OnExit += ExitApplication;
    }
    public void Exit()
    {
        
    }

    public void Enter()
    {
        
    }

    private void ExitApplication()
    {
        Debug.Log("Ex");
        _gameStateMachine.Enter<ExitApplicationState>();
        Application.Quit();
    }
}