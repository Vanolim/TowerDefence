using UnityEngine;

public class GameFactory : IGameFactory
{
    private readonly IAsset _assetsProvider;
    private readonly IStaticDataService _staticDataService;

    public GameFactory(IAsset assetsProvider, IStaticDataService staticDataService)
    {
        _assetsProvider = assetsProvider;
        _staticDataService = staticDataService;
    }

    public Hero CreateHero(Vector3 initialPosition)
    {
        Hero hero = _assetsProvider.Instantiate(AssetPath.HeroPath, initialPosition).GetComponent<Hero>();
        return hero;
    }

    public GameObject CreateLevelHub() => 
        _assetsProvider.Instantiate(AssetPath.LevelHubPath);
    public GameObject CreateMainHub() => 
        _assetsProvider.Instantiate(AssetPath.MainHubPath);
    
    public GameObject CreateLoadLevelViewButton(Transform container) => _assetsProvider.Instantiate(AssetPath.TowerLevelSceneButton, container);

    public Enemy CreateEnemy(EnemyTypeId enemyTypeId, Transform container)
    {
        EnemyStaticData enemyData = _staticDataService.ForEnemies(enemyTypeId);
        Enemy enemy = Object.Instantiate(enemyData.Prefab, container);
        InitEnemy(enemy, enemyData);
        return enemy;
    }

    private void InitEnemy(Enemy enemy, EnemyStaticData enemyData)
    {
        enemy.SetStaticData(enemyData);
    }

    public Shell CreateShell(ShellTypeId shellTypeId, Transform container)
    {
        ShellStaticData shellData = _staticDataService.ForShells(shellTypeId);
        Shell shell = Object.Instantiate(shellData.Prefab, container);
        InitShell(shell, shellData);
        return shell;
    }

    private void InitShell(Shell shell, ShellStaticData shellData)
    {
        shell.Init(shellData);
    }

    public Tower CreateTower(TowerTypeId towerTypeId, Transform container)
    {
        TowerStaticData towerData = _staticDataService.ForTowers(towerTypeId);
        Tower tower = Object.Instantiate(towerData.Prefab, container);
        InitTower(tower, towerData);
        return tower;
    }

    private void InitTower(Tower tower, TowerStaticData towerData)
    {
        tower.Init(towerData);
    }

    public CrystalMineWorking CreateMine(Transform lasMine, Transform container)
    {
        CrystalMineWorking mine = _assetsProvider.Instantiate(AssetPath.WorkCrystalMinePath, lasMine, container)
            .GetComponent<CrystalMineWorking>();
        return mine;
    }

    public TowerPlace CreateTowerPlace(Transform towerPlaceForSel, Transform container)
    {
        TowerPlace towerPlace = _assetsProvider.Instantiate(AssetPath.TowerPlacePath, towerPlaceForSel, container)
            .GetComponent<TowerPlace>();
        return towerPlace;
    }
}