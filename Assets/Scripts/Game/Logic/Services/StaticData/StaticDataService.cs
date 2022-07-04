using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;
    private Dictionary<ShellTypeId, ShellStaticData> _shells;
    private Dictionary<TowerTypeId, TowerStaticData> _towers;
    private Dictionary<string, LevelStaticData> _levelsData;
    private List<LevelData> _levelScenes;
    private SoundCollection _soundCollection;

    public void LoadEnemies()
    {
        _enemies = Resources.LoadAll<EnemyStaticData>(AssetPath.EnemiesPath)
            .ToDictionary(x => x.EnemyTypeId, x => x);
    }

    public void LoadShells()
    {
        _shells = Resources.LoadAll<ShellStaticData>(AssetPath.ShellsPath)
            .ToDictionary(x=>x.ShellTypeId, x=>x);
    }

    public void LoadTowers()
    {
        _towers = Resources.LoadAll<TowerStaticData>(AssetPath.TowersPath)
            .ToDictionary(x=>x.TowerTypeId, x=>x);
    }

    public void LoadLevelsData()
    {
        _levelsData = Resources.LoadAll<LevelStaticData>(AssetPath.LevelsDataPath)
            .ToDictionary(x => x.SceneName, x => x);
    }

    public void LoadLevelsScene() => 
        _levelScenes = Resources.LoadAll<LevelData>(AssetPath.LevelScenesPath).ToList();

    public void LoadSoundCollection() => 
        _soundCollection = Resources.Load<SoundCollection>(AssetPath.SoundCollectionPath);

    public EnemyStaticData ForEnemies(EnemyTypeId typeId) => 
        _enemies.TryGetValue(typeId, out EnemyStaticData staticData) ? staticData : null;

    public ShellStaticData ForShells(ShellTypeId typeId) => 
        _shells.TryGetValue(typeId, out ShellStaticData staticData) ? staticData : null;

    public TowerStaticData ForTowers(TowerTypeId typeId) => 
        _towers.TryGetValue(typeId, out TowerStaticData staticData) ? staticData : null;

    public LevelStaticData ForLevelsData(string sceneName) =>
        _levelsData.TryGetValue(sceneName, out LevelStaticData staticData) ? staticData : null;

    public List<LevelData> ForLevelScenes() => _levelScenes;
    public SoundCollection ForSoundCollection() => _soundCollection;
}