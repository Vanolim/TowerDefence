using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelState : IState, ICloseState
{
    private readonly NameLogicScenes _nameLogicScenes;
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IInputHandler _inputHandler;
    private readonly IStaticDataService _staticDataService;
    private readonly IPauseHandler _pauseHandler;
    private readonly ILevelData _levelData;
    private readonly IEndLevelHandler _endLevelHandler;
    private readonly IInputService _inputService;
    private readonly IAudioPlayer _audioPlayer;
    private readonly List<IDisposable> _disposables = new List<IDisposable>();

    public LoadLevelState(GameStateMachine stateMachine, 
        SceneLoader sceneLoader, 
        LoadingCurtain curtain, 
        NameLogicScenes nameLogicScenes,
        IGameFactory gameFactory, 
        IInputHandler inputHandler, 
        IStaticDataService staticDataService, 
        IPauseHandler pauseHandler, 
        ILevelData levelData,
        IEndLevelHandler endLevelHandler,
        IInputService inputService, 
        IAudioPlayer audioPlayer)
    {
        _nameLogicScenes = nameLogicScenes;
        _curtain = curtain;
        _gameFactory = gameFactory;
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _inputHandler = inputHandler;
        _staticDataService = staticDataService;
        _pauseHandler = pauseHandler;
        _levelData = levelData;
        _endLevelHandler = endLevelHandler;
        _inputService = inputService;
        _audioPlayer = audioPlayer;
    }

    public void Enter()
    {
        _curtain.Show();
        string levelSceneName = _nameLogicScenes.LevelScene;
        if (SceneManager.GetActiveScene().name == levelSceneName)
        {
            _sceneLoader.RestartScene(levelSceneName, OnLoaded);
            return;
        }
            
        _sceneLoader.Load(levelSceneName, OnLoaded);
    }

    public void Exit()
    {
        _curtain.Hide();
    }

    private void OnLoaded()
    {
        InitGameWorld();

        _stateMachine.Enter<GameLoopState>();
    }

    private void InitGameWorld()
    {
        TouchHandler touchHandler = new TouchHandler(_inputHandler);
        _pauseHandler.SetPause(false);
        _levelData.Load(_nameLogicScenes.LevelScene);
        Player player = new Player(_levelData, _pauseHandler, _audioPlayer);

        LevelSceneContextUI levelSceneContextUI = CreateHub();
        levelSceneContextUI.Init(player.Wallet, player.Health, _audioPlayer);

        ViewHandlers viewHandlers = new ViewHandlers(levelSceneContextUI, player, _pauseHandler, _audioPlayer);

        CoreLevelLogic coreLevelLogic = new CoreLevelLogic(player.PlayerVictory, _levelData, viewHandlers, _endLevelHandler, this);

        Spawners spawners = new Spawners(player.Wallet, _gameFactory, coreLevelLogic.Level.EnemySpawnScenario, _pauseHandler);

        Collections collections = new Collections(spawners, player, coreLevelLogic.UpdateGameWorld, coreLevelLogic.Level.EnemySpawnScenario);

        PlayerLogic playerLogic = new PlayerLogic(viewHandlers.PurchaseRadialViewHandler, coreLevelLogic.GameBoard,
            spawners, _staticDataService, touchHandler, _levelData, _audioPlayer);

        Hero hero = InitHero();
        coreLevelLogic.UpdateGameWorld.AddTickableItem(hero);
        CameraFollow(hero.gameObject);

        _pauseHandler.Register(coreLevelLogic.UpdateGameWorld);
        _pauseHandler.Register(_inputService);
        
        _disposables.Add(player);
        _disposables.Add(levelSceneContextUI);
        _disposables.Add(viewHandlers);
        _disposables.Add(coreLevelLogic);
        _disposables.Add(spawners);
        _disposables.Add(collections);
        _disposables.Add(playerLogic);
    }
    
    private Hero InitHero()
    {
        Hero hero = _gameFactory.CreateHero(GameObject.FindObjectOfType<PlayerInitialPoint>().GetPosition());
        hero.Init(_inputService);
        return hero;
    }

    private LevelSceneContextUI CreateHub() => _gameFactory.CreateLevelHub().GetComponentInChildren<LevelSceneContextUI>();

    private void CameraFollow(GameObject hero)
    {
        if (Camera.main != null) 
            Camera.main.GetComponent<FollowingCamera>().SetFollowObject(hero);
    }

    public void CloseState()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}