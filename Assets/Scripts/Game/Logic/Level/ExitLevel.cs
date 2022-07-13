public class ExitLevel : IDisposable
{
    private readonly ICloseState _level;
    private readonly IEndLevelHandler _endLevelHandler;
    private readonly ViewHandlers _viewHandlers;
    private readonly PlayerVictory _playerVictory;
    private bool _isPlayerPasselLevel = false;
    public ExitLevel(ViewHandlers viewHandlers, PlayerVictory playerVictory, IEndLevelHandler endLevelHandler, ICloseState level)
    {
        _viewHandlers = viewHandlers;
        _playerVictory = playerVictory;
        _endLevelHandler = endLevelHandler;
        _level = level;
        
        _playerVictory.OnVictory += Victory;
        
        _viewHandlers.OnExitMenu += Exit;
        _viewHandlers.OnReturnLevel += ReturnLevel;
    }

    public void Dispose()
    {
        _playerVictory.OnVictory -= Victory;
        _viewHandlers.OnExitMenu -= Exit;
        _viewHandlers.OnReturnLevel -= ReturnLevel;
    }
    
    private void Victory() =>  _isPlayerPasselLevel = true;
    private void Exit() => _endLevelHandler.ExitMenu(_level, _isPlayerPasselLevel);
    private void ReturnLevel() => _endLevelHandler.ReturnLevel(_level, _isPlayerPasselLevel);
}