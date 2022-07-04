using System;
using UnityEngine;

public class SpawnerEnemy : IDisposable
{
    private Transform _container;
    private readonly Wallet _wallet;
    private readonly IGameFactory _gameFactory;
    private readonly EnemySpawnScenario _enemySpawnScenario;
    
    private const string ContainerTag = "SpawnerEnemyContainer";

    public event Action<Enemy> OnSpawned;
    
    public SpawnerEnemy(Wallet wallet, IGameFactory gameFactory, EnemySpawnScenario enemySpawnScenario)
    {
        _wallet = wallet;
        _gameFactory = gameFactory;
        _enemySpawnScenario = enemySpawnScenario;

        enemySpawnScenario.OnGetEnemy += Spawn;
        enemySpawnScenario.OnFinished += Dispose;
        FindContainer();
    }

    private void FindContainer()
    {
        _container = GameObject.FindWithTag(ContainerTag).transform;
    }

    private void Spawn(EnemyTypeId enemyTypeId, Path path)
    {
        Enemy enemy = _gameFactory.CreateEnemy(enemyTypeId, _container);
        enemy.Init(new EnemyPath(path));
        _wallet.AddProduce(enemy);
        OnSpawned?.Invoke(enemy);
        PlayEffectSpawnWaypoint(path);
    }

    private static void PlayEffectSpawnWaypoint(Path path)
    {
        path.SpawnWaypoint.PlayParticle();
        path.SpawnWaypoint.PlayAudio();
    }

    public void Dispose()
    {
        _enemySpawnScenario.OnGetEnemy -= Spawn;
        _enemySpawnScenario.OnFinished -= Dispose;
    }
}
