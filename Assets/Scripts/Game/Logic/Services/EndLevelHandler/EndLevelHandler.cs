using System;

public class EndLevelHandler : IEndLevelHandler
{
    public bool IsLevelPassed { get; private set; }
    public event Action OnReturnLevel;
    public event Action OnExitMenu;

    public void ReturnLevel(ICloseState level, bool isLevelPassed)
    {
        IsLevelPassed = isLevelPassed;
        level.CloseState();
        OnReturnLevel?.Invoke();
    }

    public void ExitMenu(ICloseState level, bool isLevelPassed)
    {
        IsLevelPassed = isLevelPassed;
        level.CloseState();
        OnExitMenu?.Invoke();
    }
}