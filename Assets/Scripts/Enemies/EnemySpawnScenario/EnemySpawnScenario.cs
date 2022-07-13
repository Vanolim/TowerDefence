using System;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawnScenario : ITickable
{
    private readonly IReadOnlyList<WaveEnemies> _waves;
    private Dictionary<string, SpawnWaypoint> _spawnWaypoints;
    
    private readonly GameBoard _gameBoard;

    public event Action OnFinished;
    public event Action<EnemyTypeId, Path> OnGetEnemy;

    public EnemySpawnScenario(GameBoard gameBoard, ILevelData levelData)
    {
        _gameBoard = gameBoard;
        _waves = levelData.WaveEnemies;
        
        InitSpawnWaypoints();
    }

    private void InitSpawnWaypoints()
    {
        SpawnWaypoint[] spawnWaypoints = _gameBoard.SpawnWaypoints;
        _spawnWaypoints = new Dictionary<string, SpawnWaypoint>();

        for (int i = 0; i < spawnWaypoints.Length; i++)
        {
            SpawnWaypoint spawnWaypoint = spawnWaypoints[i];
            _spawnWaypoints.Add(spawnWaypoint.GetId(), spawnWaypoint);
        }
    }

    public void Tick(float dt)
    {
        if (IsWavesEmpty()) 
            OnFinished?.Invoke();

        foreach (var wave in _waves)
        {
            if (wave.IsEmpty)
            {
                continue;
            }
            
            wave.SetDeltaTime(dt);
            if (IsWaveReadySpawn(wave))
            {
                EnemyTypeId enemyTypeId = wave.TryGetEnemy();
                
                if (enemyTypeId != EnemyTypeId.None)
                    OnGetEnemy?.Invoke(enemyTypeId, _gameBoard.GetPath(_spawnWaypoints[wave.SpawnWaypointId]));
            }
        }
    }

    private bool IsWavesEmpty() => _waves.All(wave => wave.IsEmpty != false);
    private bool IsWaveReadySpawn(WaveEnemies wave) => wave.WaveActive && wave.IsEmpty == false;
}
