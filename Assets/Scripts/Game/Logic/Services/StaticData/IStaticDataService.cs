using System.Collections.Generic;

public interface IStaticDataService : IService
{
    void LoadEnemies();
    void LoadShells();
    void LoadTowers();
    void LoadLevelsData();
    void LoadLevelsScene();
    void LoadSoundCollection();
    EnemyStaticData ForEnemies(EnemyTypeId typeId);
    ShellStaticData ForShells(ShellTypeId typeId);
    TowerStaticData ForTowers(TowerTypeId typeId);
    LevelStaticData ForLevelsData(string sceneName);
    List<LevelData> ForLevelScenes();
    SoundCollection ForSoundCollection();
}