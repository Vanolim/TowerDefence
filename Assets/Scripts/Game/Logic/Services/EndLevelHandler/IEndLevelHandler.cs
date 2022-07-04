using System;

public interface IEndLevelHandler : IService
{
    public bool IsLevelPassed { get; }
    public event Action OnReturnLevel;
    public event Action OnExitMenu;

    public void ReturnLevel(ICloseState level, bool isLevelPassed);
    public void ExitMenu(ICloseState level, bool isLevelPassed);
}