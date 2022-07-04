using System;
using System.Collections.Generic;

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
            _spawnWaypoints.Add(spawnWaypoint.GetComponent<SpawnWaypointUniqueId>().Id, spawnWaypoint);
        }
    }

    public void Tick()
    {
        if (IsWavesEmpty()) 
            OnFinished?.Invoke();

        foreach (var wave in _waves)
        {
            if (wave.IsEmpty)
            {
                continue;
            }
            if (wave.WaveActive && wave.IsEmpty == false)
            {
                var enemyTypeId = wave.TryGetEnemy();
                
                if (enemyTypeId != EnemyTypeId.None)
                    OnGetEnemy?.Invoke(enemyTypeId, _gameBoard.GetPath(_spawnWaypoints[wave.SpawnWaypointId]));
            }
        }
    }

    private bool IsWavesEmpty()
    {
        foreach (var wave in _waves)
        {
            if (wave.IsEmpty == false)
            {
                return false;
            }
        }
        return true;
    }
}
