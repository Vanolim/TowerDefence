public class LevelLoader : IDisposable
{
    private InitializerLevelView _initializerLevelView;
    private readonly LevelViewHandler _levelViewHandler;

    public LevelLoader(
        LevelView levelView, 
        NameLogicScenes nameLogicScenes, 
        GameStateMachine gameStateMachine,
        ICloseState closeState, 
        IAudioPlayer audioPlayer, 
        IGameFactory gameFactory, 
        ISaveLoad saveLoad,
        IStaticDataService staticDataService)
    {
        _initializerLevelView = new InitializerLevelView(levelView, staticDataService, saveLoad, gameFactory);
        _levelViewHandler = new LevelViewHandler(levelView, nameLogicScenes, gameStateMachine, closeState, audioPlayer);
    }

    public void Dispose()
    {
        _levelViewHandler.Dispose();
    }
}