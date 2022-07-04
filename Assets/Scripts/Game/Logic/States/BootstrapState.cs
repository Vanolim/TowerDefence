using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;
    private readonly NameLogicScenes _nameLogicScenes;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services, NameLogicScenes nameLogicScenes)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _services = services;
        _nameLogicScenes = nameLogicScenes;

        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(_nameLogicScenes.InitialScene, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
        
    }

    private void EnterLoadLevel() => _stateMachine.Enter<LoadMainScene>();

    private void RegisterServices()
    {
        RegisterStaticData();
        
        _services.RegisterSingle(InputService());
        _services.RegisterSingle<IInputHandler>(new InputHandler(_services.Single<IInputService>()));
        _services.RegisterSingle<IPauseHandler>(new PauseHandler());
        _services.RegisterSingle<IAsset>(new AssetProvider());
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAsset>(),
            _services.Single<IStaticDataService>()));
        _services.RegisterSingle<ILevelData>(new LevelSceneData(_services.Single<IStaticDataService>()));
        _services.RegisterSingle<IEndLevelHandler>(new EndLevelHandler());
        _services.RegisterSingle<ISaveLoad>(new SaveLoad());
        _services.RegisterSingle<IAudioPlayer>(new AudioPlayer(_services.Single<IStaticDataService>().ForSoundCollection()));
    }

    private void RegisterStaticData()
    {
        IStaticDataService staticData = new StaticDataService();
        staticData.LoadEnemies();
        staticData.LoadShells();
        staticData.LoadTowers();
        staticData.LoadLevelsData();
        staticData.LoadLevelsScene();
        staticData.LoadSoundCollection();
        _services.RegisterSingle(staticData);
    }

    private static IInputService InputService()
    {
        IInputService input;
        if (Application.isMobilePlatform)
        {
            input = new MobileInput();
        }
        else
        {
            input = new StandaloneInputService();
        }
        input.Init();
        return input;
    }
}