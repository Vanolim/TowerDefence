using System;

public interface IInputHandler : IService
{
    public event Action<ITouchable> OnTouch;
}