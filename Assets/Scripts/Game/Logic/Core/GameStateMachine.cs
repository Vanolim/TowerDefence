using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, NameLogicScenes nameLogicScenes, AllServices services)
    {
        _states = new Dictionary<Type, IExitableState>
        {
            [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services, nameLogicScenes),

            [typeof(LoadMainScene)] = new LoadMainScene(this, sceneLoader, curtain, nameLogicScenes, 
                services.Single<IGameFactory>(), 
                services.Single<ISaveLoad>(),
                services.Single<IStaticDataService>(),
                services.Single<IAudioPlayer>()),

            [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain, nameLogicScenes,
                services.Single<IGameFactory>(), 
                services.Single<IInputHandler>(), 
                services.Single<IStaticDataService>(), 
                services.Single<IPauseHandler>(),
                services.Single<ILevelData>(),
                services.Single<IEndLevelHandler>(),
                services.Single<IInputService>(),
                services.Single<IAudioPlayer>()),
            
            [typeof(GameLoopState)] = new GameLoopState(this),
            
            [typeof(ExitLevelState)] = new ExitLevelState(this, 
                services.Single<IEndLevelHandler>(), services.Single<ISaveLoad>(), nameLogicScenes),
        };
    }
     
    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();
        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;
}