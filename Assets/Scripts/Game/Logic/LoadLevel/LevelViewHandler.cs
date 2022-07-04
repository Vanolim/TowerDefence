public class LevelViewHandler : IDisposable
{
    private readonly NameLogicScenes _nameLogicScenes;
    private readonly GameStateMachine _gameStateMachine;
    private readonly LevelView _levelView;
    private readonly ICloseState _closeState;
    private readonly IAudioPlayer _audioPlayer;
    
    public LevelViewHandler(LevelView levelView, NameLogicScenes nameLogicScenes, 
        GameStateMachine gameStateMachine, ICloseState closeState, IAudioPlayer audioPlayer)
    {
        _levelView = levelView;
        _nameLogicScenes = nameLogicScenes;
        _gameStateMachine = gameStateMachine;
        _closeState = closeState;
        _audioPlayer = audioPlayer;
        Init();
    }

    private void Init()
    {
        foreach (var button in _levelView.LevelViewButtons)
        {
           button.Key.Play.onClick.AddListener(delegate { PlaySound(); LoadScene(button.Value); });
        }
    }

    private void LoadScene(string sceneName)
    {
        _nameLogicScenes.SetLevelScene(sceneName);
        _closeState.CloseState();
        _gameStateMachine.Enter<LoadLevelState>();
    }

    public void Dispose()
    {
        foreach (var button in _levelView.LevelViewButtons)
        {
            button.Key.Play.onClick.RemoveListener(delegate { PlaySound(); LoadScene(button.Value); });
        }
    }

    private void PlaySound() => _audioPlayer.PlaySelectButton();
}