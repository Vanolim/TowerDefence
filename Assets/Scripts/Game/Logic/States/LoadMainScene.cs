using System.Collections.Generic;
using UnityEngine;

public class LoadMainScene : IState, ICloseState
{
    private readonly LoadingCurtain _curtain;
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _gameStateMachine;
    private readonly NameLogicScenes _nameLogicScenes;
    private readonly IGameFactory _gameFactory;
    private readonly ISaveLoad _saveLoad;
    private readonly IStaticDataService _staticDataService;
    private readonly IAudioPlayer _audioPlayer;
    private readonly IExitApplicationHandler _exitApplicationHandler;
    private readonly List<IDisposable> _disposables = new List<IDisposable>();

    public LoadMainScene(
        GameStateMachine gameStateMachine, 
        SceneLoader sceneLoader,
        LoadingCurtain curtain, 
        NameLogicScenes nameLogicScenes, 
        IGameFactory gameFactory, 
        ISaveLoad saveLoad, 
        IStaticDataService staticDataService,
        IAudioPlayer audioPlayer,
        IExitApplicationHandler exitApplicationHandler)
    {
        _gameStateMachine = gameStateMachine;
        _gameFactory = gameFactory;
        _saveLoad = saveLoad;
        _staticDataService = staticDataService;
        _audioPlayer = audioPlayer;
        _exitApplicationHandler = exitApplicationHandler;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _nameLogicScenes = nameLogicScenes;
    }

    public void Enter()
    {
        _curtain.Show();
        _sceneLoader.Load(_nameLogicScenes.MainScene, OnLoaded);
    }
    
    private void OnLoaded()
    {
        InitGameWorld();

        _gameStateMachine.Enter<GameLoopState>();
    }

    private void InitGameWorld()
    {
        MainSceneContextUI levelSceneContextUI = CreateHub();

        LevelLoader levelLoader = new LevelLoader(
            levelSceneContextUI.LevelView,
            _nameLogicScenes,
            _gameStateMachine,
            this,
            _audioPlayer,
            _gameFactory,
            _saveLoad,
            _staticDataService);

        ExitApplication exitApplication = new ExitApplication(levelSceneContextUI.ExitApplication, _exitApplicationHandler);
        
        _disposables.Add(levelLoader);
        _disposables.Add(exitApplication);
        
        InitAudioPlayer();
        _audioPlayer.ChangeMusic();
        _audioPlayer.PlayMusic();
    }

    private void InitAudioPlayer() => 
        _audioPlayer.SetAudioSource(Transform.FindObjectOfType<AudioSourceSound>(), Transform.FindObjectOfType<AudioSourceMusic>());

    private MainSceneContextUI CreateHub() => _gameFactory.CreateMainHub().GetComponentInChildren<MainSceneContextUI>();

    public void CloseState()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }

    public void Exit()
    {
        _curtain.Hide();
    }
}