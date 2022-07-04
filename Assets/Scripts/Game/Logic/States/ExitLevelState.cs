public class ExitLevelState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly NameLogicScenes _nameLogicScenes;
    private readonly ISaveLoad _saveLoad;
    private readonly IEndLevelHandler _endLevelHandler;

    public ExitLevelState(GameStateMachine gameStateMachine, IEndLevelHandler endLevelHandler, ISaveLoad saveLoad, NameLogicScenes nameLogicScenes)
    {
        _gameStateMachine = gameStateMachine;
        _endLevelHandler = endLevelHandler;
        _saveLoad = saveLoad;
        _nameLogicScenes = nameLogicScenes;

        endLevelHandler.OnExitMenu += delegate
        {
            EnterState();
            ExitToMenu();
        };
        endLevelHandler.OnReturnLevel += delegate
        {
            EnterState();
            ReturnLevel();
        };
    }

    public void Exit()
    {
        
    }

    public void Enter()
    {
        
    }
    
    private void EnterState()
    {
        _saveLoad.SaveLevelPass(_nameLogicScenes.LevelScene, _endLevelHandler.IsLevelPassed);
        _gameStateMachine.Enter<ExitLevelState>();
    }

    private void ReturnLevel() => _gameStateMachine.Enter<LoadLevelState>();

    private void ExitToMenu() => _gameStateMachine.Enter<LoadMainScene>();
}