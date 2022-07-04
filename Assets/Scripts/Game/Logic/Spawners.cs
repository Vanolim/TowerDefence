public class Spawners : IDisposable
{
    public SpawnerEnemy SpawnerEnemy { get; }
    public SpawnerShell  SpawnerShell{ get; }
    public SpawnerTowerPlace SpawnerTowerPlace { get; }
    public SpawnerTower SpawnerTower { get; }
    public SpawnerCrystalMine SpawnerCrystalMine { get; }
    
    
    public Spawners(Wallet wallet, IGameFactory gameFactory, EnemySpawnScenario enemySpawnScenario, IPauseHandler pauseHandler)
    {
        SpawnerEnemy = new SpawnerEnemy(wallet, gameFactory, enemySpawnScenario);
        SpawnerShell = new SpawnerShell(gameFactory);
        SpawnerTowerPlace = new SpawnerTowerPlace(gameFactory);
        SpawnerTower = new SpawnerTower(gameFactory, SpawnerShell);
        SpawnerCrystalMine = new SpawnerCrystalMine(gameFactory, wallet, pauseHandler);
    }

    public void Dispose()
    {
        SpawnerEnemy.Dispose();
    }
}