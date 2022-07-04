using System.Collections.Generic;

public class LevelSceneData : ILevelData
{
    private readonly IStaticDataService _staticDataService;
    private LevelStaticData _levelStaticData;
    
    public IReadOnlyList<WaveEnemies> WaveEnemies => _levelStaticData.WavesEnemies;
    public IReadOnlyList<TowerTypeId> TowersType => _levelStaticData.Towers;
    public int CountInitialBalance => _levelStaticData.CountInitialCrystal;
    public int TowerPlacePrice => _levelStaticData.TowerPlacePrice;
    public int CrystalMinePrice => _levelStaticData.CrystalMinePrice;

    public LevelSceneData(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    public void Load(string sceneName) => _levelStaticData =  _staticDataService.ForLevelsData(sceneName).Instance;
}