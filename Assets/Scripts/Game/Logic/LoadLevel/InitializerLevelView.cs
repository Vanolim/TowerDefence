using System;
using System.Collections.Generic;
using UnityEngine;

public class InitializerLevelView
{
    private readonly IStaticDataService _staticDataService;
    private readonly ISaveLoad _saveLoad;
    private readonly IGameFactory _gameFactory;
    private readonly LevelView _levelView;
    private readonly Dictionary<LevelData, bool> _levelScenesIsPassed = new Dictionary<LevelData, bool>();

    public InitializerLevelView(LevelView levelView, IStaticDataService staticDataService, ISaveLoad saveLoad, IGameFactory gameFactory)
    {
        _staticDataService = staticDataService;
        _saveLoad = saveLoad;
        _levelView = levelView;
        _gameFactory = gameFactory;

        Init();
        InitView();
    }

    private void Init()
    {
        foreach (var levelScene in Load())
        {
            bool isPassed = LoadLevelPassage(levelScene.SceneName);
            _levelScenesIsPassed.Add(levelScene, isPassed);
        }
    }

    private void InitView()
    {
        Transform viewContainer = _levelView.Container;
        foreach (var levelSceneIsPassed in _levelScenesIsPassed)
        {
            var levelScene = levelSceneIsPassed.Key;
            LevelViewButton levelViewButton =
                _gameFactory.CreateLoadLevelViewButton(viewContainer).GetComponent<LevelViewButton>();
            
            levelViewButton.Init(levelScene.LevelName, levelScene.ImageForButton, levelSceneIsPassed.Value);
            _levelView.AddLoadLevelButton(levelViewButton, levelScene.SceneName);
        }
    }

    private List<LevelData> Load() => _staticDataService.ForLevelScenes();

    private bool LoadLevelPassage(string nameScene)
    {
        if (_saveLoad.IsKeyHave(nameScene))
        {
            return Convert.ToBoolean(_saveLoad.LoadLevelPass(nameScene));
        }
        
        _saveLoad.SetNewKey(nameScene); 
        return Convert.ToBoolean(_saveLoad.LoadLevelPass(nameScene));   
    }
}