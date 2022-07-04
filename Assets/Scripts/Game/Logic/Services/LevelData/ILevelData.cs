using System.Collections.Generic;

public interface ILevelData : IService
{
    IReadOnlyList<WaveEnemies> WaveEnemies { get; }
    IReadOnlyList<TowerTypeId> TowersType { get; }
    int CountInitialBalance { get; }
    int TowerPlacePrice { get; }
    int CrystalMinePrice { get; }

    public void Load(string sceneName);
}