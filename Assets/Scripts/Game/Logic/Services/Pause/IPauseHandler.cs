public interface IPauseHandler : IService
{
    public bool IsPaused { get; }
    void SetPause(bool isPaused);
    public void Register(IPauseble handler);
    public void Unregister(IPauseble handler);
}