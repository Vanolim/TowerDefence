using System;

public interface IExitApplicationHandler : IService
{
    public event Action OnExit; 
    public void Exit();
}