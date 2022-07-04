public class Game
{ 
    public GameStateMachine StateMachine { get; }

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, NameLogicScenes nameLogicScenes)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, nameLogicScenes, AllServices.Container);
    }
}