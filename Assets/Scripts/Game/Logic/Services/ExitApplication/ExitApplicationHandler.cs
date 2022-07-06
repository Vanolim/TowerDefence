using System;

public class ExitApplicationHandler : IExitApplicationHandler
{
    public event Action OnExit;
    
    public void Exit()
    {
        OnExit?.Invoke();
    }
}