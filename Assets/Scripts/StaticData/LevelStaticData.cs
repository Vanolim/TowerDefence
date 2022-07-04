using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/LevelData")]
public class LevelStaticData : NotMutateSO<LevelStaticData>
{
    public string SceneName;
    public List<WaveEnemies> WavesEnemies;
    public List<TowerTypeId> Towers;
    public int CountInitialCrystal;
    public int TowerPlacePrice;
    public int CrystalMinePrice;
    protected override LevelStaticData GetInstance()
    {
        return this;
    }
}