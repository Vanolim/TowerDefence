using System.Collections.Generic;
using UnityEngine;

public interface IGameFactory : IService
{
    Hero CreateHero(Vector3 initialPosition);
    GameObject CreateLevelHub();
    GameObject CreateMainHub();
    GameObject CreateLoadLevelViewButton(Transform container);
    Enemy CreateEnemy(EnemyTypeId enemyTypeId, Transform container);
    Shell CreateShell(ShellTypeId shellTypeId, Transform container);
    Tower CreateTower(TowerTypeId towerTypeId, Transform container);
    CrystalMineWorking CreateMine(Transform pastMine, Transform container);
    TowerPlace CreateTowerPlace(Transform towerPlaceForSel, Transform container);
}