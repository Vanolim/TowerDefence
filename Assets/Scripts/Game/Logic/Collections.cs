using System.Collections.Generic;

public class Collections : IDisposable
{
    public EnemyCollection EnemyCollection { get; }
    public ShellCollection ShellCollection { get; }
    public TowerCollection TowerCollection { get; }
    public Collections(Spawners spawners, Player player, UpdateGameWorld updateGameWorld, EnemySpawnScenario enemySpawnScenario)
    {
        EnemyCollection = new EnemyCollection(spawners.SpawnerEnemy, player.Health, player.PlayerVictory, enemySpawnScenario);
        ShellCollection = new ShellCollection(spawners.SpawnerShell);
        TowerCollection = new TowerCollection(spawners.SpawnerTower);
        
        updateGameWorld.AddTickableItem(EnemyCollection);
        updateGameWorld.AddTickableItem(ShellCollection);
        updateGameWorld.AddTickableItem(TowerCollection);
    }

    public void Dispose()
    {
        EnemyCollection.Dispose();
        ShellCollection.Dispose();
        TowerCollection.Dispose();
    }
}