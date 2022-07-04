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
        
        _playerVictory.OnVictory += delegate { _isPlayerPasselLevel = true; };
        
        _viewHandlers.OnExitMenu += delegate { _endLevelHandler.ExitMenu(_level, _isPlayerPasselLevel);};
        _viewHandlers.OnReturnLevel += delegate { _endLevelHandler.ReturnLevel(_level, _isPlayerPasselLevel);};
    }

    public void Dispose()
    {
        _playerVictory.OnVictory -= delegate { _isPlayerPasselLevel = true; };
        _viewHandlers.OnExitMenu -= delegate { _endLevelHandler.ExitMenu(_level, _isPlayerPasselLevel);};
        _viewHandlers.OnReturnLevel -= delegate { _endLevelHandler.ReturnLevel(_level, _isPlayerPasselLevel);};
    }
}