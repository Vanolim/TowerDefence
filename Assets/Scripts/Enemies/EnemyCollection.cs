using System.Collections.Generic;

public class EnemyCollection : ITickable, IDisposable
{
    private readonly SpawnerEnemy _spawnerEnemy;
    private readonly Health _playerHealth;
    private readonly PlayerVictory _playerVictory;
    private readonly EnemySpawnScenario _enemySpawnScenario;
    private readonly List<Enemy> _enemies = new List<Enemy>();
    private bool _isEnemySpawnScenarioFinish = false;

    public EnemyCollection(SpawnerEnemy spawnerEnemy, Health playerHealth, PlayerVictory playerVictory,
        EnemySpawnScenario enemySpawnScenario)
    {
        _spawnerEnemy = spawnerEnemy;
        _playerHealth = playerHealth;
        _playerVictory = playerVictory;
        _enemySpawnScenario = enemySpawnScenario;
        
        _spawnerEnemy.OnSpawned += Add;
        _enemySpawnScenario.OnFinished += SetIsEnemySpawnScenarioFinish;
    }

    private void Add(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.OnDestroyed += Reclaim;
        enemy.OnFinish += RemoveHealthPlayer;
    }

    public void Tick()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].Tick();
        }
    }
    
    private void Reclaim(Enemy enemy)
    {
        enemy.OnDestroyed -= Reclaim;
        enemy.OnFinish -= RemoveHealthPlayer;
        RemoveEnemy(enemy);
    }
    
    private void RemoveHealthPlayer() => _playerHealth.RemoveHealth();
    private void SetIsEnemySpawnScenarioFinish() => _isEnemySpawnScenarioFinish = true;

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if(_enemies.Count == 0 && _isEnemySpawnScenarioFinish)
            _playerVictory.Win();
    }

    public void Dispose()
    {
        _spawnerEnemy.OnSpawned -= Add;
        _enemySpawnScenario.OnFinished -= SetIsEnemySpawnScenarioFinish;
    }
}
