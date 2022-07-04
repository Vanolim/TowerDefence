using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    public LoadingCurtain Curtain;
    public NameLogicScenes NameLogicScenes;
    private Game _game;

    private void Awake()
    {
        _game = new Game(this, Curtain, NameLogicScenes);
        _game.StateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}