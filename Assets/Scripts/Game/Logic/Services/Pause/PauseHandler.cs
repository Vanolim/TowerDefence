using System.Collections.Generic;

public class PauseHandler : IPauseHandler
{
    private readonly List<IPauseble> _handlers = new List<IPauseble>();
    
    public bool IsPaused { get; private set; }

    public void Register(IPauseble handler) => _handlers.Add(handler);

    public void Unregister(IPauseble handler) => _handlers.Remove(handler);

    public void SetPause(bool isPaused)
    {
        IsPaused = isPaused;
        foreach (var handler in _handlers)
        {
            handler.SetPause(isPaused);
        }
    }
}